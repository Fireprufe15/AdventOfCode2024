using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day6
{
    public static class GuardRoutePathSolver
    {
        public static int SolveForPositions(string input, bool findLoops = false)
        {
            var map = GuardRouteMapParser.Parse(input);
            var initialGuardPosition = GetGuardPosition(map);
            if (initialGuardPosition == null)
            {
                Console.WriteLine("No guard position found");
                return 0;
            }
            var mapAfterRoute = RunRoute(map, initialGuardPosition);
            var positionCount = 0;

            if (findLoops)
            {
                int loopedPositionCount = 0;

                var listOfRoutePositions = new List<GuardPosition>();
                var unAllowedPosition = GetGuardPosition(map);
                for (int x = 0; x < mapAfterRoute.Map.GetLength(0); x++)
                {
                    for (int y = 0; y < mapAfterRoute.Map.GetLength(1); y++)
                    {
                        if (x == unAllowedPosition.X && y == unAllowedPosition.Y) continue;
                        if (mapAfterRoute.Map[x, y] == 'X')
                        {
                            listOfRoutePositions.Add(new GuardPosition() { X = x, Y = y });
                        }
                    }
                }
                var finalGuardPos = GetGuardPosition(mapAfterRoute.Map);
                listOfRoutePositions.Add(finalGuardPos);

                int progressTracker = 0;
                var loopedPaths = new List<GuardPosition>();
                
                Parallel.ForEach(listOfRoutePositions, position =>
                {
                    progressTracker++;
                    Console.Clear();
                    Console.WriteLine($"Checking position {progressTracker} of {listOfRoutePositions.Count}");

                    var newMap = map.Clone() as char[,];
                    newMap[position.X, position.Y] = '#';
                    var guardPos = GetGuardPosition(map);
                    var mapAfterRouteForPosition = RunRoute(newMap, guardPos);
                    if (mapAfterRouteForPosition.HasLooped)
                    {
                        lock (loopedPaths)
                        {
                            loopedPaths.Add(position);
                        }
                    }
                });

                return loopedPaths.Count;
            } 
            else
            {
                for (int x = 0; x < mapAfterRoute.Map.GetLength(0); x++)
                {
                    for (int y = 0; y < mapAfterRoute.Map.GetLength(1); y++)
                    {
                        if (mapAfterRoute.Map[x, y] == 'X')
                        {
                            positionCount++;
                        }
                    }
                }

                PrintMap(mapAfterRoute.Map);
                
                return positionCount + 1;
            }
            
        }

        private static void PrintMap(char[,] map)
        {
            Console.Clear();
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }

        private static GuardPosition? GetGuardPosition(char[,] map)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == '^' || map[x,y] == '>' || map[x,y] == '<' || map[x,y] == 'v')
                    {
                        return new GuardPosition() { X = x, Y = y};
                    }
                }
            }
            return null;
        }

        private static MapOutput RunRoute(char[,] startingMap, GuardPosition initialGuardPosition)
        {
            var looped = false;
            var guardPositionsDuringRoute = new List<GuardPosition>();
            var map = startingMap.Clone() as char[,];
            while (!looped && initialGuardPosition.X > -1 && initialGuardPosition.X < map.GetLength(0) && initialGuardPosition.Y > -1 && initialGuardPosition.Y < map.GetLength(1))
            {
                var guardOrientation = map[initialGuardPosition.X, initialGuardPosition.Y];
                var preMovePosition = new GuardPosition() { X = initialGuardPosition.X, Y = initialGuardPosition.Y };
                if (guardOrientation == '^')
                {
                    initialGuardPosition.Y--;
                }
                else if (guardOrientation == '>')
                {
                    initialGuardPosition.X++;
                }
                else if (guardOrientation == 'v')
                {
                    initialGuardPosition.Y++;
                }
                else if (guardOrientation == '<')
                {
                    initialGuardPosition.X--;
                }
                try
                {
                    if (map[initialGuardPosition.X, initialGuardPosition.Y] == '#')
                    {
                        initialGuardPosition.X = preMovePosition.X;
                        initialGuardPosition.Y = preMovePosition.Y;
                        if (guardOrientation == '^')
                        {
                            map[initialGuardPosition.X, initialGuardPosition.Y] = '>';
                            guardOrientation = '>';
                        }
                        else if (guardOrientation == '>')
                        {
                            map[initialGuardPosition.X, initialGuardPosition.Y] = 'v';
                            guardOrientation = 'v';
                        }
                        else if (guardOrientation == 'v')
                        {
                            map[initialGuardPosition.X, initialGuardPosition.Y] = '<';
                            guardOrientation = '<';
                        }
                        else if (guardOrientation == '<')
                        {
                            map[initialGuardPosition.X, initialGuardPosition.Y] = '^';
                            guardOrientation = '^';
                        }
                    }
                    else
                    {
                        map[initialGuardPosition.X, initialGuardPosition.Y] = guardOrientation;
                        map[preMovePosition.X, preMovePosition.Y] = 'X';
                        if (guardPositionsDuringRoute.Any(x => x.X == initialGuardPosition.X && x.Y == initialGuardPosition.Y && x.Orientation == guardOrientation))
                        {
                            looped = true;
                        }
                        guardPositionsDuringRoute.Add(new GuardPosition() { X = initialGuardPosition.X, Y = initialGuardPosition.Y, Orientation = guardOrientation });
                    }
                }
                catch (Exception)
                {//Just moving on
                }
            }
            var output = new MapOutput() { Map = map, HasLooped = looped };
            return output;
        }
    }

    public class GuardPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Orientation { get; set; }
    }

    public class MapOutput {         
        public char[,] Map { get; set; }
        public bool HasLooped { get; set; }
    }
}

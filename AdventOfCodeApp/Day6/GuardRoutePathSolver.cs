using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day6
{
    public static class GuardRoutePathSolver
    {
        public static int SolveForPositions(string input)
        {
            var map = GuardRouteMapParser.Parse(input);
            var initialGuardPosition = GetGuardPosition(map);
            if (initialGuardPosition == null)
            {
                Console.WriteLine("No guard position found");
                return 0;
            }
            while (initialGuardPosition.X > -1 && initialGuardPosition.X < map.GetLength(0) && initialGuardPosition.Y > -1 && initialGuardPosition.Y < map.GetLength(1))
            {
                
                // Draw map in console window
                //Console.Clear();
                //for (int y = 0; y < map.GetLength(1); y++)
                //{
                //    for (int x = 0; x < map.GetLength(0); x++)
                //    {
                //        Console.Write(map[x, y]);
                //    }
                //    Console.WriteLine();
                //}

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
                    } else
                    {
                        map[initialGuardPosition.X, initialGuardPosition.Y] = guardOrientation;
                        map[preMovePosition.X, preMovePosition.Y] = 'X';
                    }
                }
                catch (Exception)
                {//Just moving on
                 }
            }
            var positionCount = 0;
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == 'X')
                    {
                        positionCount++;
                    }
                }
            }
            Console.Clear();
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
            return positionCount+1;
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
    }

    public class GuardPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day8
{
    public static class AntennaMapSolver
    {
        public static int SolveAntinodeCount(string input, bool resonate = false)
        {
            var map = AntennaMapParser.ParseMap(input);
            var antinodeLocations = new List<MapLocation>();
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] != '.')
                    {
                        var antennas = GetAntennasWithSameFrequency(map, map[x, y]).Where(loc => loc.X != x && loc.Y != y);                        
                        
                        if (resonate && antennas.Any() && !antinodeLocations.Exists(pos => pos.X == x && pos.Y == y))
                            antinodeLocations.Add(new MapLocation { X = x, Y = y });


                        foreach (var antenna in antennas)
                        {
                            var isResonating = resonate;
                            var xDiff = antenna.X - x;
                            var yDiff = antenna.Y - y;
                            do
                            {
                                var newX = antenna.X + xDiff;
                                var newY = antenna.Y + yDiff;
                                if (newX >= 0 && newX < map.GetLength(0) && newY >= 0 && newY < map.GetLength(1))
                                {
                                    if (!antinodeLocations.Exists(pos => pos.X == newX && pos.Y == newY))
                                    {
                                        antinodeLocations.Add(new MapLocation { X = newX, Y = newY });
                                    }
                                    antenna.X = newX;
                                    antenna.Y = newY;
                                }
                                else isResonating = false;

                            } while (isResonating);

                        }
                    }
                }
            }
            return antinodeLocations.Count;
        }

        private static List<MapLocation> GetAntennasWithSameFrequency(char[,] map, char frequency)
        {
            var locations = new List<MapLocation>();
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == frequency)
                    {
                        locations.Add(new MapLocation { X = x, Y = y });
                    }
                }
            }

            return locations;
        }

    }

    public class MapLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}

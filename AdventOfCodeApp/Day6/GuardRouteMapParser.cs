using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day6
{
    public static class GuardRouteMapParser
    {
        public static char[,] Parse(string text)
        {
            var lines = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var map = new char[lines[0].Length, lines.Length];
            for (int x = 0; x < lines[0].Length; x++)
            {
                for (int y = 0; y < lines.Length; y++)
                {
                    map[x, y] = lines[y][x];
                }
            }
            return map;
        }
    }
}

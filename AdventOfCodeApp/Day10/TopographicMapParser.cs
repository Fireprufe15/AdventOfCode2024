using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day10
{
    public static class TopographicMapParser
    {
        public static int[,] Parse(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var map = new int[lines[0].Length, lines.Length];
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[0].Length; x++)
                {
                    map[x, y] = int.Parse(lines[y][x].ToString());
                }
            }
            return map;
        }
    }
}

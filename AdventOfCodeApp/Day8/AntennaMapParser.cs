using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day8
{
    public static class AntennaMapParser
    {
        public static char[,] ParseMap(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day4
{
    public static class DerangedWordSearchParser
    {
        public static string[,] Parse(string text)
        {
            var lines = text.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            var array = new string[lines.Count, lines[0].Length];
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    array[i, j] = lines[i][j].ToString();
                }
            }
            return array;
        }
    }
}

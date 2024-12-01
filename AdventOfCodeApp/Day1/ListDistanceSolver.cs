using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day1
{
    public class ListDistanceSolver
    {
        public int Solve(string input)
        {
            var lists = ParseLists(input);
            return 0;
        }

        private List<List<int>> ParseLists(string input)
        {
            var lines = input.Split("\n");
            var cols = lines[0].Split("   ").Count();
            var listOfLists = new List<List<int>>();
            for (int i = 0; i < cols; i++)
            {
                listOfLists.Add(new List<int>());
            }
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var colsInLine = line.Split("   ");
                for (int i = 0; i < colsInLine.Length; i++)
                {
                    listOfLists[i].Add(int.Parse(colsInLine[i]));
                }
            }
            return listOfLists;
        }
    }
}

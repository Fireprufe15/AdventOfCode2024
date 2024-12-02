using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day1
{
    public static class ListDistanceSolver
    {
        public static int Solve(string input)
        {
            var lists = HistorianListParser.ParseLists(input);
            foreach (var list in lists)
            {
                list.Sort();
            }

            int totalDistance = 0;
            for (int i = 0; i < lists[0].Count; i++)
            {
                totalDistance += Math.Abs(lists[0][i] - lists[1][i]);
            }

            return totalDistance;
        }
    }
}

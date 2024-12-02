using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day1
{
    public static class ListSimilaritySolver
    {
        public static int Solve(string input)
        {
            var lists = HistorianListParser.ParseLists(input);

            var totalSimilarity = 0;
            foreach (var item in lists[0])
            {
                totalSimilarity += item * lists[1].Where(x => x == item).Count();
            }

            return totalSimilarity;
        }
    }
}

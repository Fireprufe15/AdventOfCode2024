using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day1
{
    public class ListSimilaritySolver
    {
        public int Solve(string input)
        {
            var lists = Parser.ParseLists(input);

            var totalSimilarity = 0;
            foreach (var item in lists[0])
            {
                totalSimilarity += item * lists[1].Where(x => x == item).Count();
            }

            return totalSimilarity;
        }
    }
}

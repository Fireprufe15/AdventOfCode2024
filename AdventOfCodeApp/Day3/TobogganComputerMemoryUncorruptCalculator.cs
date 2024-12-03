using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day3
{
    public static class TobogganComputerMemoryUncorruptCalculator
    {
        public static int Solve(string input, bool considerConditionals = false)
        {
            var total = 0;
            Regex regex = new Regex(@"mul\((\d+,\d+)\)|do\(\)|don't\(\)");
            var matches = regex.Matches(input);
            var skipOps = false;
            foreach (Match match in matches)
            {
                if (considerConditionals && match.Value == "don't()") { skipOps = true; continue; }
                if (considerConditionals && match.Value == "do()") { skipOps = false; continue; }
                if (!skipOps)
                {
                    var numbersString = match.Groups[1].Value;
                    var numbers = numbersString.Split(",").Select(int.Parse).ToList();
                    var result = numbers[0] * numbers[1];
                    total += result;
                }
            }
            return total;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day5
{
    public static class PrintRequestParser
    {
        public static PrintRequest Parse(string input)
        {
            Regex rulesRegex = new Regex(@"\d+\|\d+");
            var matches = rulesRegex.Matches(input);
            var rules = matches.Select(m => new Tuple<int, int>(int.Parse(m.Value.Split("|")[0]), int.Parse(m.Value.Split("|")[1]))).ToList();
            
            var reqsRegex = new Regex(@"(\d+,)+\d+");
            var reqsMatches = reqsRegex.Matches(input);
            var reqs = reqsMatches.Select(m => m.Value.Split(",").Select(int.Parse).ToList()).ToList();

            var PrintRequest = new PrintRequest
            {
                Rules = rules,
                Updates = reqs
            };

            return PrintRequest;
        }
    }
}

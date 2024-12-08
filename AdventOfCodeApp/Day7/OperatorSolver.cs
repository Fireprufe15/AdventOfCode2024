using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day7
{
    public static class OperatorSolver
    {
        public static int Solve(string input)
        {
            var equations = OperatorParser.Parse(input);
            var trueableEquationsSum = 0;
            foreach (var equation in equations)
            {

            }
            return trueableEquationsSum;
        }
    }
}

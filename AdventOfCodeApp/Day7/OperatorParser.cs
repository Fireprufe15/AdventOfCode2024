using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCodeApp.Day7
{
    public static class OperatorParser
    {
        public static List<Equation> Parse(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var equations = new List<Equation>();
            foreach (var line in lines)
            {
                var split = line.Split(':');
                var numbers = split[1].Trim().Split(' ').Select(int.Parse).ToArray();
                equations.Add(new Equation
                {
                    TestValue = int.Parse(split[0]),
                    Numbers = numbers
                });
                
            }
            return equations;
        }
    }

    public class Equation
    {
        public int TestValue { get; set; }
        public int[] Numbers { get; set; }
    }
}

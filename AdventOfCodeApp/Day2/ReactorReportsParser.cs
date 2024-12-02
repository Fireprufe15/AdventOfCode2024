using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day2
{
    public static class ReactorReportsParser
    {
        public static List<List<int>> Parse(string input)
        {
            var reports = new List<List<int>>();
            var lines = input.Split("\n");
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                var report = new List<int>();
                var reportItems = line.Split(" ");
                report.AddRange(reportItems.Select(int.Parse));
                reports.Add(report);
            }

            return reports;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day2
{
    public static class ReportSafetySolver
    {
        public static int Solve(string input, bool useProblemDampener = false)
        {
            var reports = ReactorReportsParser.Parse(input);
            var safeReports = 0;
            var unsafeReportsList = new List<List<int>>();
            foreach (var report in reports)
            {           
                var unsafeIndex = GetReportUnsafeIndex(report);
                if (unsafeIndex == -1) safeReports += 1;
                else unsafeReportsList.Add(report);
            }

            Console.WriteLine("Safe reports: "+safeReports);

            if (useProblemDampener)
            {
                Console.WriteLine("Problem dampener engaged!");
                foreach (var report in unsafeReportsList)
                {
                    for (int i = 0; i < report.Count; i++)
                    {
                        var newReport = new List<int>(report);
                        newReport.RemoveAt(i);
                        var unsafeIndex = GetReportUnsafeIndex(newReport);
                        if (unsafeIndex == -1)
                        {
                            safeReports += 1;
                            break;
                        }
                    }
                }
            }

            return safeReports;
        }

        private static int GetReportUnsafeIndex(List<int> report)
        {
            int currentCheckNumber = report[0];
            bool isAscending = report[1] > report[0];
            for (int i = 1; i < report.Count; i++)
            {
                if (Math.Abs(currentCheckNumber - report[i]) > 3 || Math.Abs(currentCheckNumber - report[i]) < 1)
                {
                    Console.WriteLine("ALERT! ANOMOLY! Unsafe because of difference higher than 3");
                    return i;
                }

                if ((isAscending && report[i] < currentCheckNumber) || (!isAscending && report[i] > currentCheckNumber))
                {
                    Console.WriteLine("ALERT! ANOMOLY! Unsafe because breaking of ascending/descending pattern");
                    return i;
                }

                currentCheckNumber = report[i];
            }
            return -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day5
{
    public class PrintRequest
    {
        public List<Tuple<int, int>> Rules { get; set; }
        public List<List<int>> Updates { get; set; }
    }
}

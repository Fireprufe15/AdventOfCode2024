using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp
{
    public interface IParser
    {
        List<List<int>> Parse(string input);
    }
}

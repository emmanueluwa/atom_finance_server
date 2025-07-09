using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atom_finance_server.Helpers
{
    public class QueryObject
    {
        public string? Symbol { get; set; } = null;

        public string? Company { get; set; } = null;

        public string? SortBy { get; set; } = null;

        public bool IsDescending { get; set; } = false;
    }
}

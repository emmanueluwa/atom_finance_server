using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atom_finance_server.Helpers
{
    public class CommentQueryObject
    {
        public string Symbol { get; set; }
        public bool IsDescending { get; set; } = true;
    }
}

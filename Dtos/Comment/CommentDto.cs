using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace atom_finance_server.Dtos.Comment
{
    public class CommentDto
    {
        
        public int Id { get; set; }
        public string Title { get; set; }  = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty;
        public int? StockId { get; set; }
    }
}

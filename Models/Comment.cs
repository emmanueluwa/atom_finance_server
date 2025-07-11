using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace atom_finance_server.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
        //navigation property - allows us to access into model
        public Stock? Stock { get; set; }

        //one to one
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}

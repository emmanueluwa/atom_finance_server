using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/*
Portfolio is actually a join table implementing a many-to-many relationship between AppUser and Stock 
- it represents a single stock holding within a user's portfolio, not an entire portfolio collection. 
Each Portfolio record represents "User X owns Stock Y," each Portfolio entry belongs to one AppUser and one Stock, 
while users and stocks can appear in many Portfolio records.

*/

namespace atom_finance_server.Models
{
    //join table - many to many
    [Table("Portfolios")]
    public class Portfolio
    {
        public string AppUserId { get; set; }
        public int StockId { get; set; }
        public AppUser AppUser { get; set; }
        public Stock Stock { get; set; }
    }
}

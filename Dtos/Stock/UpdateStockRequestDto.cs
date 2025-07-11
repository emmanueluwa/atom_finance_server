using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace atom_finance_server.Dtos.Stock
{
    public class UpdateStockRequestDto
    {

        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be more than 10 characters.")]        public string Symbol { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000000000000)]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Industry cannot be more than 10 characters.")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(1, 5000000000000)]
        public long MarketCap { get; set; }
        
    }
}

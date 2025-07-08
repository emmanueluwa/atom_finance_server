using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atom_finance_server.Data;
using atom_finance_server.Dtos.Stock;
using atom_finance_server.Mappers;
using atom_finance_server.Models;
using Microsoft.AspNetCore.Mvc;

namespace atom_finance_server.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //ToList - deferred excecution
            var stocks = _context.Stocks.ToList()
                .Select(s => s.ToStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.FromCreateStockDtoToStock();
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }
    }
}

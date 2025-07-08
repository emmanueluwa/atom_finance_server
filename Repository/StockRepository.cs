using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atom_finance_server.Data;
using atom_finance_server.Interfaces;
using atom_finance_server.Models;
using Microsoft.EntityFrameworkCore;

namespace atom_finance_server.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            //bringing in the db to "preheat the oven"
            _context = context;
        }

        public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stocks.ToListAsync();
        }
    }
}

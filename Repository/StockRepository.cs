using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atom_finance_server.Data;
using atom_finance_server.Dtos.Stock;
using atom_finance_server.Interfaces;
using atom_finance_server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);

            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync((x) => x.Id == id);

            if (stockModel == null)
            {
                return null;
            }

            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.Include((c) => c.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            var stockModel = await _context.Stocks.Include((c) => c.Comments).FirstOrDefaultAsync((x) => x.Id == id);

            if (stockModel == null)
            {
                return null;
            }

            return stockModel;
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync((s) => s.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var existingStockModel = await _context.Stocks.FirstOrDefaultAsync((x) => x.Id == id);
            if (existingStockModel == null)
            {
                return null;
            }

            existingStockModel.Symbol = stockDto.Symbol;
            existingStockModel.Company = stockDto.Company;
            existingStockModel.Purchase = stockDto.Purchase;
            existingStockModel.LastDiv = stockDto.LastDiv;
            existingStockModel.Industry = stockDto.Industry;
            existingStockModel.MarketCap = stockDto.MarketCap;

            await _context.SaveChangesAsync();

            return existingStockModel;
        }
    }
}

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
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync((c) => c.Id == id);
            if (commentModel == null)
            {
                return null;
            }

            return commentModel;
        }
    }
}

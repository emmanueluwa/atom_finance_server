using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atom_finance_server.Interfaces;
using atom_finance_server.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace atom_finance_server.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();

            var commentDto = comments.Select((c) => c.fromCommentToCommentDto());

            return Ok(commentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.fromCommentToCommentDto());
        }
    }
}

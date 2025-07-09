using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace atom_finance_server.Dtos.Comment
{
    public class UpdateCommentDto
    {
        [Required]
        [MinLength(4, ErrorMessage = "Title must be atleast 4 characts")]
        [MaxLength(280, ErrorMessage = "Title cannot be more than 280 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(4, ErrorMessage = "Comment must be atleast 4 characts")]
        [MaxLength(280, ErrorMessage = "Comment cannot be more than 280 characters")]
        public string Content { get; set; } = string.Empty;
    }
}

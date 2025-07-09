using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atom_finance_server.Dtos.Comment;
using atom_finance_server.Models;

namespace atom_finance_server.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto fromCommentToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId
            };

        }

        public static Comment fromCreateCommentDtoToComment(this CreateCommentDto commentDto, int stockId)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId
            };

        }

        public static Comment fromUpdateCommentDtoToComment(this UpdateCommentDto commentDto)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
            };

        }
    }
}

using FiveMinusThree.Api.Models;
using FiveMinusThree.Api.DTOs.ReplyDTO;
using Microsoft.EntityFrameworkCore;
using FiveMinusThree.Api.Data;
namespace FiveMinusThree.Api.Repository.ReplyRepository
{
    public class ReplyRepository : IReplyRepository
    {
        protected readonly FiveMinusThreeContext _context;
        public ReplyRepository(FiveMinusThreeContext context)
        {
            _context = context;
        }
        public async Task Create(ReplyCreateDTO reply,Guid userId,Guid postId,Guid replyTo)
        {
            _context.Add(new Reply
            {
                ReplyTo = replyTo,
                UserId = userId,
                PostId = postId,
                Content = reply.Content,
            }) ;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await _context.Database.ExecuteSqlRawAsync($"DELETE FROM REPLIES WHERE {id}");
        }

        public async Task<List<Reply>> GetAll(Guid postId)
        {
           return await _context.Replies.Where(r => r.PostId == postId).ToListAsync();
        }
    }
}

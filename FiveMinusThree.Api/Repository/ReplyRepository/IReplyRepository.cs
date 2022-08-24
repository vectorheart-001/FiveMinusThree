using FiveMinusThree.Api.DTOs.ReplyDTO;
using FiveMinusThree.Api.Models;

namespace FiveMinusThree.Api.Repository.ReplyRepository
{
    public interface IReplyRepository
    {
        public Task<List<Reply>> GetAll(Guid id);
        public Task Delete(Guid id);
        public Task Create(ReplyCreateDTO reply, Guid userId, Guid postId, Guid replyTo);
    }
}

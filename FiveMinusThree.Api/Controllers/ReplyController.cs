using Microsoft.AspNetCore.Mvc;
using FiveMinusThree.Api.DTOs.ReplyDTO;
using FiveMinusThree.Api.Models;
using FiveMinusThree.Api.Repository.ReplyRepository;
using FiveMinusThree.Api.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace FiveMinusThree.Api.Controllers
{
    public class ReplyController:ControllerBase
    {
        protected readonly IReplyRepository _replyRepository;
        public ReplyController(IReplyRepository replyRepository)
        {
            _replyRepository = replyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid postId)
        {
            return Ok(await _replyRepository.GetAll(postId));
        }
        [HttpDelete("delete-reply")]
        public async Task<IActionResult> Delete(Guid replyId)
        {
            await _replyRepository.Delete(replyId);
            return Ok();
        }
        [Authorize]
        [HttpPost("create-reply")]
        public async Task<IActionResult> Create([FromBody] ReplyCreateDTO reply, Guid postId, Guid replyTo)
        {
            string rawId = HttpContext.User.FindFirstValue("id");
            Guid.TryParse(rawId, out Guid userId);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _replyRepository.Create(reply, userId, postId, replyTo);
            return Ok();
        }
    }
}

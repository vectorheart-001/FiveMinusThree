
using Microsoft.AspNetCore.Mvc;
using FiveMinusThree.Api.DTOs.PostDTO;
using FiveMinusThree.Api.Models;
using FiveMinusThree.Api.Repository.PostRepository;
using FiveMinusThree.Api.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FiveMinusThree.Api.Controllers
{
    public class PostController : ControllerBase
    {
        protected readonly IPostRepository _postRepository;
        
        
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
            
        }
        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody]PostCreateDTO post,Guid themeId)
        {
            string rawid = HttpContext.User.FindFirstValue("id");
            Guid.TryParse(rawid, out Guid userid);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            await _postRepository.Create(post, userid ,themeId);
            return Ok();
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (_postRepository.Exists(id) == false)
            {
                return NotFound();
            }
            return Ok(await _postRepository.GetBydId(id));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllPosts(Guid themeId)
        {
            return Ok(await _postRepository.GetAll(themeId));
        }

        [HttpDelete("delete")]
        [Authorize]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            if (_postRepository.Exists(id) == false)
            {
                return NotFound();
            }
            await _postRepository.Delete(id);
            return Ok();
        }

        [HttpPost("update-post")]
        public async Task<IActionResult> UpdatePost(PostUpdateDTO post)
        {
            if (_postRepository.Exists(post.Id) == false)
            {
                return NotFound();
            }
            await _postRepository.Update(post);
            return Ok();
        }

    }
}

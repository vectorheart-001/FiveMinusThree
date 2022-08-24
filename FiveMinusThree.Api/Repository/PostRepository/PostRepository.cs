using FiveMinusThree.Api.Models;
using FiveMinusThree.Api.DTOs.PostDTO;
using FiveMinusThree.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace FiveMinusThree.Api.Repository.PostRepository
{
    public class PostRepository : IPostRepository
    {
        protected readonly FiveMinusThreeContext _context;
        public PostRepository(FiveMinusThreeContext context)
        {
            _context = context;
        }

        public async Task Create(PostCreateDTO postDto, Guid id, Guid themeId)
        {
            _context.Add(new Post()
            {
                Content = postDto.Content,
                Title = postDto.Title,
                ThemeId = postDto.ThemeId,
                UserId = null,
                CreatedDate = DateTime.Now,
            }) ;
            await _context.SaveChangesAsync();
           
        }

        public async Task Delete(Guid id)
        {
            await _context.Database.ExecuteSqlRawAsync($"DELETE FROM POSTS WHERE ID = {id}");
            await _context.SaveChangesAsync();
        }

        public bool Exists(Guid id)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Post>> GetAll(Guid themeId)
        {
            return await _context.Posts.Where(p => p.ThemeId == themeId).ToListAsync();
            
        }

        public async Task<Post> GetBydId(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<List<Post>> GetByTitle(string searchword)
        {
            return await _context.Posts.Where(p => p.Title.Contains(searchword)).ToListAsync();
        }

        public async Task Update(PostUpdateDTO post)
        {
            var postUpdated = _context.Posts.Find(post.Id);
            _context.Posts.Update(postUpdated);
            _context.SaveChangesAsync();
            
        }

        
    }
}

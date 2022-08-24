using FiveMinusThree.Api.DTOs.PostDTO;
using FiveMinusThree.Api.Models;
namespace FiveMinusThree.Api.Repository.PostRepository
{
    public interface IPostRepository
    {

        public Task<List<Post>> GetAll(Guid id);
        public bool Exists(Guid id); 
        public Task Create(PostCreateDTO post, Guid userId,Guid themeId);
        Task Update(PostUpdateDTO post);
        public Task<Post> GetBydId(Guid id);
        public Task<List<Post>> GetByTitle(string searchword);
        public Task Delete(Guid id);

    }
}

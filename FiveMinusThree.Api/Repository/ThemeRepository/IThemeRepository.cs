using FiveMinusThree.Api.Models;
using FiveMinusThree.Api.DTOs.ThemeDTO;
namespace FiveMinusThree.Api.Repository.ThemeRepository
{
    public interface IThemeRepository
    {
        public Task<List<Theme>> GetAll();
        public Task Delete(Guid id);
        public Task Create (ThemeDTO themeDTO);
    }
}

using FiveMinusThree.Api.Data;
using Microsoft.EntityFrameworkCore;
using FiveMinusThree.Api.Models;
using FiveMinusThree.Api.DTOs.ThemeDTO;

namespace FiveMinusThree.Api.Repository.ThemeRepository
{
    public class ThemeRepository : IThemeRepository
    {
        protected readonly FiveMinusThreeContext _context;
        public ThemeRepository(FiveMinusThreeContext context)
        {
            _context = context;
        }

        public async Task Create(ThemeDTO themeDTO)
        {
            _context.Add(new Theme
            {
                Description = themeDTO.Description,
                Name = themeDTO.Name,
            });
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await _context.Database.ExecuteSqlRawAsync($"DELETE FROM Themes WHERE Id = {id}");
        }

        public async Task<List<Theme>> GetAll()
        {
            return await _context.Themes.ToListAsync();
        }
    }
}

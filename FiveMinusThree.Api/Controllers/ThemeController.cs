using Microsoft.AspNetCore.Mvc;
using FiveMinusThree.Api.Models;
using FiveMinusThree.Api.Repository.ThemeRepository;
using FiveMinusThree.Api.DTOs.ThemeDTO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FiveMinusThree.Api.Controllers
{
    public class ThemeController : ControllerBase
    {
        protected readonly IThemeRepository _themeRepository;
        public ThemeController(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }
        [HttpGet("get-all-themes")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _themeRepository.GetAll());
        }
        [HttpPost("create-theme")]
        public async Task<IActionResult> Create(ThemeDTO themeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _themeRepository.Create(themeDTO);
            return Ok();
        }
        [HttpDelete("delete-theme")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _themeRepository.Delete(id);
            return Ok();
        }
    }
}

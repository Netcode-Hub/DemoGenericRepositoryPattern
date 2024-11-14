using DemoGenericRepositoryPattern.Interfaces;
using DemoGenericRepositoryPattern.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoGenericRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        // Comments updated
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandRepository.GetListAsync();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
                return NotFound();
            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            await _brandRepository.AddAsync(brand);
            return CreatedAtAction(nameof(GetById), new { id = brand.Id }, brand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Brand brand)
        {
            if (id != brand.Id)
                return BadRequest();

            await _brandRepository.UpdateAsync(brand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _brandRepository.DeleteAsync(id);
            return NoContent();
        }
    }

}

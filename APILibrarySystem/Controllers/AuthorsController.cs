using APILibrarySystem.DTOs;
using APILibrarySystem.Models;
using APILibrarySystem.Repositories;
using APILibrarySystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APILibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorsController(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _authorRepo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var author = await _authorRepo.GetByIdAsync(id);
            return author == null ? NotFound() : Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuthorDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var author = new Author
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Bio = dto.Bio,
                DateOfBirth = dto.DateOfBirth
            };

            await _authorRepo.AddAsync(author);
            await _authorRepo.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AuthorDto dto)
        {
            var author = await _authorRepo.GetByIdAsync(id);
            if (author == null) return NotFound();

            author.FirstName = dto.FirstName;
            author.LastName = dto.LastName;
            author.Bio = dto.Bio;
            author.DateOfBirth = dto.DateOfBirth;

            _authorRepo.Update(author);
            await _authorRepo.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var author = await _authorRepo.GetByIdAsync(id);
            if (author == null) return NotFound();

            _authorRepo.Delete(author);
            await _authorRepo.SaveAsync();

            return NoContent();
        }
    }
}
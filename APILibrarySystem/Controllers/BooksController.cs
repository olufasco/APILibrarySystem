using APILibrarySystem.DTOs;
using APILibrarySystem.Models;
using APILibrarySystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APILibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public BooksController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _bookRepo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var book = new Book
            {
                Title = dto.Title,
                ISBN = dto.ISBN,
                PublicationYear = dto.PublicationYear,
                AuthorId = dto.AuthorId,
                GenreId = dto.GenreId
            };

            await _bookRepo.AddAsync(book);
            await _bookRepo.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] BookDto dto)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null) return NotFound();

            book.Title = dto.Title;
            book.ISBN = dto.ISBN;
            book.PublicationYear = dto.PublicationYear;
            book.AuthorId = dto.AuthorId;
            book.GenreId = dto.GenreId;

            _bookRepo.Update(book);
            await _bookRepo.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null) return NotFound();

            _bookRepo.Delete(book);
            await _bookRepo.SaveAsync();

            return NoContent();
        }
    }
}
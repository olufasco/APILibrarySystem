using APILibrarySystem.DTOs;
using APILibrarySystem.Models;
using APILibrarySystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APILibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _unitOfWork.Books.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<Book>>.SuccessResponse(books, "Books retrieved successfully"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);
            if (book == null)
                return NotFound(ApiResponse<Book>.FailResponse("Book not found"));

            return Ok(ApiResponse<Book>.SuccessResponse(book, "Book retrieved successfully"));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] BookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse<BookDto>.FailResponse("Invalid model state"));

            var book = new Book
            {
                Title = dto.Title,
                ISBN = dto.ISBN,
                PublicationYear = dto.PublicationYear,
                AuthorId = dto.AuthorId,
                GenreId = dto.GenreId
            };

            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = book.Id },
                ApiResponse<Book>.SuccessResponse(book, "Book created successfully"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] BookDto dto)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);
            if (book == null)
                return NotFound(ApiResponse<Book>.FailResponse("Book not found"));

            book.Title = dto.Title;
            book.ISBN = dto.ISBN;
            book.PublicationYear = dto.PublicationYear;
            book.AuthorId = dto.AuthorId;
            book.GenreId = dto.GenreId;

            _unitOfWork.Books.Update(book);
            await _unitOfWork.SaveAsync();

            return Ok(ApiResponse<Book>.SuccessResponse(book, "Book updated successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);
            if (book == null)
                return NotFound(ApiResponse<Book>.FailResponse("Book not found"));

            _unitOfWork.Books.Delete(book);
            await _unitOfWork.SaveAsync();

            return Ok(ApiResponse<string>.SuccessResponse("Book deleted successfully"));
        }
    }
}
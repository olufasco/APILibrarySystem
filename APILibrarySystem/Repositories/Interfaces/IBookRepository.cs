using APILibrarySystem.Models;
using APILibrarySystem.Repositories.Implementations;
using APILibrarySystem.Repositories.Interfaces;

namespace APILibrarySystem.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> SearchAsync(string keyword);
        Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId);
        Task<IEnumerable<Book>> GetPagedBooksAsync(int page, int pageSize);
    }
}
using APILibrarySystem.Data;
using APILibrarySystem.Repositories.Interfaces;
using System.Threading.Tasks;

namespace APILibrarySystem.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _context;

        public IBookRepository Books { get; }
        public IAuthorRepository Authors { get; }
        public IGenreRepository Genres { get; }

        public UnitOfWork(LibraryDbContext context,
                          IBookRepository bookRepository,
                          IAuthorRepository authorRepository,
                          IGenreRepository genreRepository)
        {
            _context = context;
            Books = bookRepository;
            Authors = authorRepository;
            Genres = genreRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
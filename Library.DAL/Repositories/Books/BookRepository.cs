using Library.DAL.DbContexts;
using Library.DAL.Models;
using Library.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repositories.Books
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {

        public BookRepository(LibraryDbContext dbContext)
            : base(dbContext)
        {
        }

        public bool BookExists(long id, CancellationToken cancellationToken = default)
        {
            return dbContext.Set<Book>().Any(book => book.Id == id);
        }

        public async Task<Book?> GetBookByIsbnAsync(string isbn, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<Book>()
                .FirstOrDefaultAsync(book => book.ISBN == isbn, cancellationToken);
        }

        public async Task<Book?> GetBookByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<Book>()
                .FirstOrDefaultAsync(book => book.Id == id, cancellationToken);
        }

        public IQueryable<Book> GetAllBooks()
        {
            return dbContext.Set<Book>().AsQueryable();
        }
    }
}
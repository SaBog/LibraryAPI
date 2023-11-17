using Library.DAL.Models;
using Library.DAL.Repositories.Base;

namespace Library.DAL.Repositories.Books
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        IQueryable<Book> GetAllBooks();
        Task<Book?> GetBookByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<Book?> GetBookByIsbnAsync(string isbn, CancellationToken cancellationToken = default);
        bool BookExists(long id, CancellationToken cancellationToken = default);
    }
}
using Library.Application.Books.ViewModels;
using MediatR;

namespace Library.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<IReadOnlyCollection<BookViewModel>>
    {

    }
}

using Library.Application.Books.ViewModels;
using MediatR;

namespace Library.Application.Books.Queries.GetBookQuery
{
    public class GetBookQuery : IRequest<BookViewModel>
    {
        public long BookId { get; }

        public GetBookQuery(long bookId) => BookId = bookId;
    }
}

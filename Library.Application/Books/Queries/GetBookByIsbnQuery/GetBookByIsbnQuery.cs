using Library.Application.Books.ViewModels;
using MediatR;

namespace Library.Application.Books.Queries.GetBookByIsbnQuery
{
    public record GetBookByIsbnQuery(string Isbn) : IRequest<BookViewModel>;
}

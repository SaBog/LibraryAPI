using Library.Application.Books.ViewModels;
using MediatR;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<BookViewModel>
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string? Genre { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
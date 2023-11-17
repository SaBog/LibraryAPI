using MediatR;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest
    {
        public long Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime? BorrowedDate { get; set; } = null;
        public DateTime? ReturnDate { get; set; } = null;
    }

}

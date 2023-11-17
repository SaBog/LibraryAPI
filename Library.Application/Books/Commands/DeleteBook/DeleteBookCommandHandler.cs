using Library.Application.Common.Exceptions;
using Library.DAL.Models;
using Library.DAL.Repositories.Books;
using MediatR;

namespace Library.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler :
        IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _repository;

        public DeleteBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetBookByIdAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Book), request.Id);

            await _repository.DeleteAsync(entity, cancellationToken);
            return;

        }

    }
}

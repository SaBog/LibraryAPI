using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.DAL.Models;
using Library.DAL.Repositories.Books;
using MediatR;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler :
        IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            if (!_repository.BookExists(request.Id))
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            var book = _mapper.Map<Book>(request);
            await _repository.UpdateAsync(book, cancellationToken);

            return;
        }

    }
}

using AutoMapper;
using Library.Application.Books.ViewModels;
using Library.DAL.Models;
using Library.DAL.Repositories.Books;
using MediatR;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler :
        IRequestHandler<CreateBookCommand, BookViewModel>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookViewModel> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            await _repository.AddAsync(book, cancellationToken);

            var bookVM = _mapper.Map<BookViewModel>(book);
            return bookVM;

        }
    }
}
using AutoMapper;
using Library.Application.Books.ViewModels;
using Library.Application.Common.Exceptions;
using Library.DAL.Models;
using Library.DAL.Repositories.Books;
using MediatR;

namespace Library.Application.Books.Queries.GetBookQuery
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookViewModel>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetBookQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookViewModel> Handle(GetBookQuery query, CancellationToken cancellationToken)
        {
            var book = await _repository.GetBookByIdAsync(query.BookId, cancellationToken)
                ?? throw new NotFoundException(nameof(Book), query.BookId);

            return _mapper.Map<BookViewModel>(book);
        }
    }
}

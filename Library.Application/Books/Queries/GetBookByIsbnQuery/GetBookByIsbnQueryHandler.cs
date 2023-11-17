using AutoMapper;
using Library.Application.Books.ViewModels;
using Library.Application.Common.Exceptions;
using Library.DAL.Models;
using Library.DAL.Repositories.Books;
using MediatR;

namespace Library.Application.Books.Queries.GetBookByIsbnQuery
{
    public class GetBookByIsbnQueryHandler : IRequestHandler<GetBookByIsbnQuery, BookViewModel>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetBookByIsbnQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookViewModel> Handle(GetBookByIsbnQuery query, CancellationToken cancellationToken)
        {
            var book = await _repository.GetBookByIsbnAsync(query.Isbn, cancellationToken)
                ?? throw new NotFoundException(nameof(Book), query.Isbn);

            return _mapper.Map<BookViewModel>(book);
        }
    }

}

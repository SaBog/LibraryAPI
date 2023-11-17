using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Books.ViewModels;
using Library.DAL.Repositories.Books;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IReadOnlyCollection<BookViewModel>>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetAllBooksQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<BookViewModel>> Handle(GetAllBooksQuery query, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllBooks()
                .ProjectTo<BookViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return books;
        }
    }
}

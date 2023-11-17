using AutoMapper;
using Library.Application.Auth.Commands.Register;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.UpdateBook;
using Library.Application.Books.ViewModels;
using Library.DAL.Models;

namespace Library.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<Book, CreateBookCommand>().ReverseMap();
            CreateMap<Book, UpdateBookCommand>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
        }
    }
}

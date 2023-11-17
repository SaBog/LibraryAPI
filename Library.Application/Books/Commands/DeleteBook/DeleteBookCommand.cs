﻿using MediatR;

namespace Library.Application.Books.Commands.DeleteBook
{
    public record DeleteBookCommand(long Id) : IRequest;
}

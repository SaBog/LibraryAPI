using MediatR;

namespace Library.Application.Auth.Commands.Register
{
    public record RegisterUserCommand(string Name, string Email, string Password) : IRequest;
}
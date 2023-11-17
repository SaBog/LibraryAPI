using MediatR;

namespace Library.Application.Auth.Commands.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<LoginCommandResponse>;
}

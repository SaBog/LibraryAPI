using Library.Application.Common.Exceptions;
using Library.DAL.Repositories.Users;
using Library.Infrastructure.Authorization;
using MediatR;

namespace Library.Application.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken)
                ?? throw new NotFoundException($"User with {request.Email} not found");

            if (!PasswordManager.VerifyHashedPassword(user.Password, request.Password))
                throw new UserAuthenticationException();


            var token = _authService.GenerateSecurityToken(user.Id, user.Email, $"{user.Name}");
            return new LoginCommandResponse(token);
        }
    }
}
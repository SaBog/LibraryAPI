using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.DAL.Models;
using Library.DAL.Repositories.Users;
using MediatR;

namespace Library.Application.Auth.Commands.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existing_user = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);

            if (existing_user is not null)
                throw new UserWithEmailAlreadyExistsException(request.Email);

            var hashedPassword = PasswordManager.Hash(request.Password);
            var user = _mapper.Map<User>(request);
            user.Password = PasswordManager.Hash(user.Password);

            await _userRepository.AddAsync(user, cancellationToken);
            return;
        }
    }
}
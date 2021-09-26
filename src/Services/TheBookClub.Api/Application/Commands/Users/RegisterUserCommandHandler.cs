using MediatR;
using TheBookClub.Domain.AggregatesModel.UserAggregate;

namespace TheBookClub.Api.Application.Commands.Users
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.EmailAddress, request.FirstName, request.LastName, request.Password);
            _userRepository.Add(user);
            await _userRepository.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

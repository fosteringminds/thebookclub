using MediatR;
using TheBookClub.Domain.AggregatesModel.UserAggregate;

namespace TheBookClub.Api.Application.Commands.Subscriptions
{
    public class SubscriptionCommandHandler : IRequestHandler<SubscriptionCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public SubscriptionCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(SubscriptionCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetById(request.UserId);
            if (!request.IsSubscribed)
                user.AddSubscription(request.BookId);
            else
                _userRepository.RemoveSubscription(request.UserId, request.BookId);

            await _userRepository.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

using MediatR;
using System.Runtime.Serialization;

namespace TheBookClub.Api.Application.Commands.Subscriptions
{
    public class SubscriptionCommand : IRequest<bool>
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int BookId { get; set; }

        [DataMember]
        public bool IsSubscribed {  get; set; }
    }
}

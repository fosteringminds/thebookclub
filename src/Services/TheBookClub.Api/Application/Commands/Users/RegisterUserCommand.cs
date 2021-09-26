using MediatR;
using System.Runtime.Serialization;

namespace TheBookClub.Api.Application.Commands.Users
{
    public class RegisterUserCommand : IRequest<bool>
    {
        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName {  get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}

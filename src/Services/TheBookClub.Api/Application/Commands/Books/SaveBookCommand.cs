using MediatR;
using System.Runtime.Serialization;

namespace TheBookClub.Api.Application.Commands.Books
{
    public class SaveBookCommand : IRequest<bool>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string? Title {  get; set; }

        [DataMember]
        public string? Text {  get; set; }

        [DataMember]
        public decimal PurchasePrice {  get; set; }
    }
}

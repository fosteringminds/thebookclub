using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookClub.Domain.AggregatesModel.UserAggregate;
using TheBookClub.Domain.SeedWork;

namespace TheBookClub.Domain.AggregatesModel.BookAggregate
{
    public class Book : Entity, IAggregateRoot
    {
        public string? Name {  get; set; }
        public string? Text { get; set; }
        public decimal? PurchasePrice {  get; set; }
        private List<Subscription> subscriptions;
        public IEnumerable<Subscription> Subscriptions => subscriptions.AsReadOnly();

        protected Book()
        {
            subscriptions = new List<Subscription>();
        }

        public Book(string? name, string? text, decimal? purchasePrice) : this()
        {
            Name = name;
            Text = text;
            PurchasePrice = purchasePrice;
        }
        public Book(int id, string? name, string? text, decimal? purchasePrice) : this()
        {
            Id = id;
            Name = name;
            Text = text;
            PurchasePrice = purchasePrice;
        }
    }
}

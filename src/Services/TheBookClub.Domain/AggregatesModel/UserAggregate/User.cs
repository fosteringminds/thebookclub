using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookClub.Domain.AggregatesModel.BookAggregate;
using TheBookClub.Domain.SeedWork;

namespace TheBookClub.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity, IAggregateRoot
    {
        protected User()
        {
            subscriptions = new List<Subscription>();
        }

        public User(string emailAddress, string firstName, string lastName, string password) : this()
        {
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
        public User(int id, string emailAddress, string firstName, string lastName, string password) : this()
        {
            Id = id;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }


        private List<Subscription> subscriptions;
        public IEnumerable<Subscription> Subscriptions => subscriptions.AsReadOnly();

        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName {  get; set; }
        public string Password { get; set; }

        public Subscription AddSubscription(int bookId)
        {
            var subscription = new Subscription(bookId, Id);
            if (!subscriptions.Any(x => x.BookId == bookId))
                subscriptions.Add(subscription);
            return subscription;
        }

        //public void RemoveSubscription(int bookId)
        //{
        //    var subscription = new Subscription(bookId, Id);
        //    if (subscriptions.Any(x => x.BookId == bookId))
        //        subscriptions.Remove(subscription);
        //}
    }
}

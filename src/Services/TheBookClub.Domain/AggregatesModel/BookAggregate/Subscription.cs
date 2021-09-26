using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookClub.Domain.AggregatesModel.UserAggregate;

namespace TheBookClub.Domain.AggregatesModel.BookAggregate
{
    public class Subscription : Entity
    {
        public Subscription(int id, int bookId, int userId)
        {
            Id = id;
            BookId = bookId;
            UserId = userId;
        }
        public Subscription(int bookId, int userId)
        {
            BookId = bookId;
            UserId = userId;
        }

        public int BookId { get; set; }
        public int UserId { get; set; }

        public Book Book { get; set; }
        public User User {  get; set; }
    }
}

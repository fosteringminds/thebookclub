using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookClub.Domain.AggregatesModel.UserAggregate;
using TheBookClub.Domain.SeedWork;

namespace TheBookClub.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly SubscribtionManagementContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public UserRepository(SubscribtionManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public User Add(User user)
        {
            return _context.Users.Add(user).Entity;
        }

        public User Update(User user)
        {
            return _context.Users.Update(user).Entity;
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public void RemoveSubscription(int userId, int bookId)
        {
            if(_context.Subscriptions.Any(u => u.UserId == userId && u.BookId == bookId))
            {
                foreach(var subscription in _context.Subscriptions.Where(u => u.UserId == userId && u.BookId == bookId))
                {
                    _context.Entry(subscription).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookClub.Domain.SeedWork;

namespace TheBookClub.Domain.AggregatesModel.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    {
        User Add(User user);
        User Update(User user);
        User GetById(int id);
        void RemoveSubscription(int userId, int bookId);
    }
}

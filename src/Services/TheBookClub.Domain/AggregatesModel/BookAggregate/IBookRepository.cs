using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookClub.Domain.SeedWork;

namespace TheBookClub.Domain.AggregatesModel.BookAggregate
{
    public interface IBookRepository : IRepository<Book>
    {
        Book Add(Book catalogueItem);
        Book Update(Book catalogueItem);
    }
}

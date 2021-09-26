using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookClub.Domain.AggregatesModel.BookAggregate;
using TheBookClub.Domain.SeedWork;

namespace TheBookClub.Infrastructure.Repositories.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly SubscribtionManagementContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public BookRepository(SubscribtionManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Book Add(Book book)
        {
            return _context.Books.Add(book).Entity;
        }

        public Book Update(Book book)
        {
            return _context.Books.Update(book).Entity;
        }
    }
}

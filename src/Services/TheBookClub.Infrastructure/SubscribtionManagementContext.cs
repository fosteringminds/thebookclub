using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookClub.Domain.AggregatesModel.BookAggregate;
using TheBookClub.Domain.AggregatesModel.UserAggregate;
using TheBookClub.Domain.SeedWork;

namespace TheBookClub.Infrastructure
{
    public class SubscribtionManagementContext : DbContext, IUnitOfWork
    {
        public DbSet<Book>? Books {get; set;}
        public DbSet<User>? Users { get; set;}
        public DbSet<Subscription>? Subscriptions { get; set; }
        public SubscribtionManagementContext(DbContextOptions<SubscribtionManagementContext> options) : base(options) { }
    }
}

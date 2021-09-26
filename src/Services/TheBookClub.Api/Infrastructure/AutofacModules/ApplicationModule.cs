using Autofac;
using TheBookClub.Api.Queries;
using TheBookClub.Domain.AggregatesModel.BookAggregate;
using TheBookClub.Domain.AggregatesModel.UserAggregate;
using TheBookClub.Infrastructure.Repositories.Books;
using TheBookClub.Infrastructure.Repositories.Users;

namespace TheBookClub.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new UserQueries(QueriesConnectionString))
                .As<IUserQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookRepository>()
                .As<IBookRepository>()
                .InstancePerLifetimeScope();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookClub.Domain.AggregatesModel.BookAggregate;
using TheBookClub.Domain.AggregatesModel.UserAggregate;
using Xunit;

namespace TheBookClub.Tests.Domain
{
    public class UserAggregateTest
    {
        public UserAggregateTest()
        {

        }

        [Fact]
        public void Create_User_Subscription_Test()
        {
            var book = new Book(1, "The Great Gatsby", "Things of pages and text", 200);
            var user = new User(1, "test@test.co.za", "Test", "User", "Test@123");

            var subscription = user.AddSubscription(book.Id);
            Assert.NotNull(subscription);
            Assert.True(user.Subscriptions.Any());
        }
    }
}

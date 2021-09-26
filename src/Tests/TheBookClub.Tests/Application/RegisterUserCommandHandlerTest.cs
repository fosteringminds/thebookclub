using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TheBookClub.Api.Application.Commands.Users;
using TheBookClub.Domain.AggregatesModel.UserAggregate;
using Xunit;

namespace TheBookClub.Tests.Application
{
    public class RegisterUserCommandHandlerTest
    {
        Mock<IUserRepository> userRepositoryMock;
        public RegisterUserCommandHandlerTest()
        {
            userRepositoryMock = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task Register_User_Test()
        {
            string emailAddress = "test@test.co.za";
            string password = "password";
            string firstName = "Test";
            string lastName = "User";
            var registerUserCommand = new RegisterUserCommand();
            registerUserCommand.EmailAddress = emailAddress;
            registerUserCommand.Password = password;
            registerUserCommand.FirstName = firstName;
            registerUserCommand.LastName = lastName;

            userRepositoryMock.Setup(userRepo => userRepo.Add(new User(emailAddress, firstName, lastName, password))).Returns(new User(emailAddress, firstName, lastName, password));
            userRepositoryMock.Setup(buyerRepo => buyerRepo.UnitOfWork.SaveChangesAsync(default(CancellationToken)))
                .Returns(Task.FromResult(1));
            var registerUserCommandHandler = new RegisterUserCommandHandler(userRepositoryMock.Object);
            var cltToken = new System.Threading.CancellationToken();
            var result = await registerUserCommandHandler.Handle(registerUserCommand,cltToken);

            Assert.True(result);
        }
    }
}

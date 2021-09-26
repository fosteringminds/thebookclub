using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TheBookClub.Api.Application.Commands.Subscriptions;
using TheBookClub.Api.Application.Commands.Users;
using TheBookClub.Api.Middleware;
using TheBookClub.Api.Queries;

namespace TheBookClub.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        IMediator _mediator;
        IUserQueries _userQueries;
        IOptions<AppSettings> _appSettings;
        public UserController(IMediator mediator, IUserQueries userQueries, IOptions<AppSettings> appSettings)
        {
            _mediator = mediator;
            _userQueries = userQueries;
            _appSettings = appSettings;
        }

        [Route("api/user/register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            var registerUserCommand = new RegisterUserCommand();
            registerUserCommand.EmailAddress = userViewModel.EmailAddress;
            registerUserCommand.FirstName = userViewModel.FirstName;
            registerUserCommand.LastName = userViewModel.LastName;
            registerUserCommand.Password = userViewModel.Password;
            return Ok(await _mediator.Send(registerUserCommand));
        }

        [Route("api/user/authenticate")]
        public async Task<IActionResult> Authenticate(UserViewModel userViewModel)
        {
            var user = await _userQueries.GetUser(userViewModel.EmailAddress, userViewModel.Password);

            if (user == null)
                return BadRequest("Invalid credentials");

            var token = GenerateJwtToken(user);
            user.Token = token;
            return Ok(user);
        }

        [Authorize]
        [HttpGet]
        [Route("api/user/savesubscription/{userId}/{bookId}/{isSubscribed}")]
        public async Task<IActionResult> SaveSubscription(int userId, int bookId, bool isSubscribed)
        {
            var subscriptionCommand = new SubscriptionCommand();
            subscriptionCommand.UserId = userId;
            subscriptionCommand.BookId = bookId;
            subscriptionCommand.IsSubscribed = isSubscribed;
            await _mediator.Send(subscriptionCommand);
            return Ok(await _userQueries.GetUserSubscriptions(userId));
        }

        [Authorize]
        [HttpGet]
        [Route("api/user/getusersubscriptions/{userId}")]
        public async Task<IActionResult> GetUserSubscriptions(int userId)
        {
            var bookList = await _userQueries.GetUserSubscriptions(userId);
            return Ok(bookList);
        }

        [Authorize]
        [HttpGet]
        [Route("api/user/list")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userQueries.GetUsers();
            return Ok(users);
        }

        private string GenerateJwtToken(UserViewModel userViewModel)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userViewModel.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

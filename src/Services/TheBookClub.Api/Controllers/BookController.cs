using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBookClub.Api.Application.Commands.Books;
using TheBookClub.Api.Middleware;
using TheBookClub.Api.Queries;

namespace TheBookClub.Api.Controllers
{    
    [ApiController]
    public class BookController : ControllerBase
    {
        IMediator _mediator;
        IBookQueries _bookQueries;
        public BookController(IMediator mediator, IBookQueries bookQueries)
        {
            _mediator = mediator;
            _bookQueries = bookQueries;
        }

        [Authorize]
        [Route("api/book/save")]
        [HttpPost]
        public async Task<IActionResult> SaveBook(BookViewModel bookViewModel)
        {
            var saveBookCommand = new SaveBookCommand();
            saveBookCommand.Title = bookViewModel.Title;
            saveBookCommand.PurchasePrice = bookViewModel.PurchasePrice;
            saveBookCommand.Text = bookViewModel.Text;
            saveBookCommand.Id = bookViewModel.Id;
            return Ok(await _mediator.Send(saveBookCommand));
        }

        [Authorize]
        [Route("api/book/list")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _bookQueries.GetAll());
        }
    }
}

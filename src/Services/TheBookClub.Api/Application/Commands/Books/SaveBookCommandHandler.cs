using MediatR;
using TheBookClub.Domain.AggregatesModel.BookAggregate;

namespace TheBookClub.Api.Application.Commands.Books
{
    public class SaveBookCommandHandler : IRequestHandler<SaveBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;
        public SaveBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Handle(SaveBookCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                var book = new Book(request.Title, request.Text, request.PurchasePrice);
                _bookRepository.Add(book);
            }
            else
            {
                var book = new Book(request.Id, request.Title, request.Text, request.PurchasePrice);
                _bookRepository.Update(book);
            }
            await _bookRepository.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

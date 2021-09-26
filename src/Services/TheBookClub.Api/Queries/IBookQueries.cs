namespace TheBookClub.Api.Queries
{
    public interface IBookQueries
    {
        Task<IEnumerable<BookViewModel>> GetAll();
    }
}

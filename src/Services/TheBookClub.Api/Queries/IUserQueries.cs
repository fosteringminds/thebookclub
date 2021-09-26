namespace TheBookClub.Api.Queries
{
    public interface IUserQueries
    {
        Task<UserViewModel> GetUserById(int id);
        Task<UserViewModel> GetUser(string emailAddress, string password);
        Task<IEnumerable<UserViewModel>> GetUsers();
        Task<List<BookViewModel>> GetUserSubscriptions(int userId);
    }
}

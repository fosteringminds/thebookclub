using Dapper;
using Microsoft.Data.Sqlite;

namespace TheBookClub.Api.Queries
{
    public class UserQueries : IUserQueries
    {
        private string _connectionString = string.Empty;
        public UserQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<UserViewModel> GetUserById(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryFirstAsync<UserViewModel>("select Id, EmailAddress, FirstName, LastName from Users where Id=@id", new { id = id });
            }
        }

        public async Task<UserViewModel> GetUser(string emailAddress, string password)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryFirstAsync<UserViewModel>("select Id, EmailAddress, FirstName, LastName from Users where EmailAddress=@emailAddress and Password=@password", new { emailAddress = emailAddress, password = password });
            }
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<UserViewModel>("select Id, EmailAddress, FirstName, LastName from Users");
            }
        }

        public async Task<List<BookViewModel>> GetUserSubscriptions(int userId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var query = await connection.QueryAsync<BookViewModel>("select b.Id, b.Name as Title, b.Text, b.PurchasePrice, s.UserId from Books b left join Subscriptions s on b.Id = s.BookId");
                var bookList = query.ToList();
                foreach(var book in bookList)
                {
                    if(book.UserId != null)
                    {
                        book.IsSubscribed = book.UserId == userId;
                    }
                }
                return bookList;
            }
        }
    }
}

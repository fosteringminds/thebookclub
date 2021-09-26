using Dapper;
using Microsoft.Data.Sqlite;

namespace TheBookClub.Api.Queries
{
    public class BookQueries : IBookQueries
    {
        private string _connectionString = string.Empty;
        public BookQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<BookViewModel>("select Id, Name as Title, Text, PurchasePrice from Books");
            }
        }
    }
}

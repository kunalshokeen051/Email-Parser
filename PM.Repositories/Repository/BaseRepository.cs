using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Repositories.Repository
{ 
    public class BaseRepository
    {
        protected readonly IDbConnection _connection;

        public BaseRepository(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public virtual IEnumerable<T> ExecuteQuery<T>(string query, object parameters = null, CommandType commandType = CommandType.Text)
        {
            return _connection.Query<T>(query, parameters);
        }
    }
}

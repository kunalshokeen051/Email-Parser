using Dapper;
using PM.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Repositories.Repository
{
    public class AuthRepository : BaseRepository
    {
        public AuthRepository(IDbConnection connection) : base(connection)
        {
        }

        
    }
}

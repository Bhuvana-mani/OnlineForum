using System;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForumLibrary
{
    public class SqliteUserRepository
    {
        private const string _connectionString = "Data Source=.\\Discussion_Forum_Database.db";
        public List<User> GetUsers()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {

                var users = connection.Query<User>("SELECT * FROM User");
                return users.ToList();
            }

        }
       
            
        
    }
}

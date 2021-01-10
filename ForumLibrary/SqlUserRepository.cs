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
        public List<User> UserWithThread()
        {
            using (var connection = new SqliteConnection(_connectionString)) 
            {
                var sql = "SELECT *FROM User AS u" +
                   "JOIN Thread AS t ON t.User_Id=u.Id";
                var userDictionary = new Dictionary<int, User>();
                var users = connection.Query<User, Thread, User>(sql,
                (user, thread) =>
                {
                    if (!userDictionary.ContainsKey(user.User_Id))
                    {
                        userDictionary.Add(user.User_Id, user);
                    }
                    var userEntry = userDictionary[user.User_Id];
                    userEntry.Threads.Add(thread);
                    return userEntry;
                });
                return users.Distinct().ToList();

            }
            
        }
    }
}

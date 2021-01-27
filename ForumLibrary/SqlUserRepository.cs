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
        public User GetUserById(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "SELECT * FROM User WHERE User.User_Id = @User_Id";
                return connection.QuerySingle<User>(sql, new { User_Id = id });

            }
        }

        public List<User> GetUserwithThread(User userthread)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "SELECT * FROM User " +
                    "INNER JOIN Thread ON Thread.User_Id=User.User_Id ";
                var users = connection.Query<User, Thread, User>(sql,
                    (user, threads) =>
                    {
                        user.Threads.Add(threads);
                        return user;

                    }, userthread, splitOn:"Thread_Id");
                var result = users.GroupBy(u => u.User_Id).Select(groupedUsers =>
                    {
                        var groupedUser = groupedUsers.First();
                        groupedUser.Threads = groupedUsers.Select(user => user.Threads.Single()).ToList();
                        return groupedUser;
                    });
                return result.ToList();

            }
        }


    }
}

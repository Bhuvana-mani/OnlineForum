using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace ForumLibrary
{
    public class SqlitePostRepository
    {
        private const string _connectionString = "Data Source=.\\Discussion_Forum_Database.db";

        public Post GetPostById(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "SELECT * FROM Post WHERE Post.Post_Id = @Post_Id";
                 return connection.QuerySingle<Post>(sql, new { Post_Id = id });

            }
        }


        public void Create(Post post)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "INSERT INTO Post (Comment,User_Id,Thread_Id) " +
                    "VALUES (@Comment,@User_Id,@Thread_Id); " +
                    "SELECT last_insert_rowid();";
                  var id = connection.Query<int>(sql, post);
                  post.Post_Id = id.First();

            }
        }
        public void Update(Post post)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "UPDATE Post SET Comment = @Comment WHERE Post_Id = @Post_Id ;";
                connection.Execute(sql, post);

            }
        }
        public void Delete(Post post)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "DELETE FROM Post WHERE Post_Id = @Post_Id;";
                connection.Execute(sql, post);

            }
        }
        public List<Post> WithThread(Thread thread)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                
                var sql = "SELECT * FROM Post WHERE Thread_Id=@Thread_Id ";
                return connection.Query<Post>(sql,thread ).ToList();
                

            }
        }
    }
}

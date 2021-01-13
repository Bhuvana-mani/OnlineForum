using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Linq;

namespace ForumLibrary
{
    public class SqliteThreadRepository
    {
        private const string _connectionString = "Data Source=.\\Discussion_Forum_Database.db";
        public List<Thread> GetThreads()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var alltopic = connection.Query<Thread>("SELECT * FROM Thread");
                return alltopic.ToList();

            }

        }

        public Thread GetbyId(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var query = "SELECT *FROM Thread WHERE Thread.Thread_Id=@Thread_Id";
               return connection.QuerySingle<Thread>(query, new { Thread_Id = id });

            }
        }
        public void AddThread(Thread thread)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var newthread = "INSERT INTO Thread(Content,User_Id)" +"VALUES(@Content,@User_Id);"+$"SELECT last_insert_rowid()";
               var id= connection.Query<int>(newthread, thread);
                thread.Thread_Id = id.First();
            }
        }
        
        
    }
}

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
        private const string _connectionString = "Data Source=.\\Dicussion_Forum_Database.db";
        public List<Thread> GetThreads()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var alltopic = connection.Query<Thread>("SELECT * FROM THREAD");
                return alltopic.ToList();

            }

        }

        public Thread GetbyId(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var query = "SELECT *FROM Thread WHERE Thread_Id=@Thread_Id";
               return connection.QuerySingle<Thread>(query, new { Thread_Id = id });

            }
        }
        public void AddThread(Thread thread)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var newthread = "INSERT INTO Thread(Thread_Id,Content,User_Id)" +"VALUES(@Thread_Id,@Content,@User_Id);"+$"SELECT last_insert_rowid()";
               var id= connection.Query<int>(newthread, thread);
                thread.Thread_Id = id.First();
            }
        }
        //public void UpdateThread(Thread thread)
        //{
        //    using (var connection = new SqliteConnection(_connectionString))
        //    {
        //        var update = $"UPDATE Thread SET Content=@Content,User_Id=@User_Id," + $"WHERE Thread_Id=@Thread_Id";
        //         connection.Execute(update, thread);

        //    }
        //}
        //public void DeleteThread(Thread thread)
        //{
        //    using (var connection = new SqliteConnection(_connectionString))
        //    {
        //        var delete = $"DELETE FROM Thread WHERE Thread_Id=@Thread_Id";
        //        connection.Execute(delete, thread);

        //    }
        //}
        //public List<Thread> WithPosts()
        //{
        //    using (var connection = new SqliteConnection(_connectionString))
        //    {
        //        var sql = "SELECT *FROM Thread AS t"+
        //            "JOIN Post AS p ON p.Thread_Id=t.Id";
        //        var threadDictionary = new Dictionary<int, Thread>();
        //        var threads = connection.Query<Thread, Post, Thread>(sql,
        //        (thread, post) =>
        //        {
        //            if (!threadDictionary.ContainsKey(thread.Thread_Id))
        //            {
        //                threadDictionary.Add(thread.Thread_Id, thread);
        //            }
        //            var threadEntry=threadDictionary[thread.Thread_Id];
        //            threadEntry.Posts.Add(post);
        //            return threadEntry;
        //        });
        //        return threads.Distinct().ToList();
               
        //    }
        //}
    }
}

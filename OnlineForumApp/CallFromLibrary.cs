using System;
using System.Collections.Generic;
using System.Text;
using ForumLibrary;

namespace OnlineForumApp
{
    class CallFromLibrary
    {
        private SqliteThreadRepository _threadRepo = new SqliteThreadRepository();
        private SqliteUserRepository _userRepo = new SqliteUserRepository();
        private SqlitePostRepository _postRepo = new SqlitePostRepository();
        public void PrintThread()
        {
            var thread = _threadRepo.GetThreads();
            foreach(var thre in thread)
            {
                PrintaThread(thre);
            }
        }
        public void ThreadbyId(int id)
        {
            var thre = _threadRepo.GetbyId(id);
            PrintaThread(thre);

        }
        public void CreateThread()
        {
            var thre = new Thread();
            Console.WriteLine("Enter your user Id:");
            thre.User_Id =int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a content for the thread:");
            thre.Content = Console.ReadLine();
            _threadRepo.AddThread(thre);
        }
        public void ThreadwithPost(SqlitePostRepository prepo,SqliteThreadRepository trepo)
        {
            Console.WriteLine("Enter a thread Id");
            var tId = int.Parse(Console.ReadLine());
            var mthread = trepo.GetbyId(tId);
            var mpost = prepo.WithThread(mthread);

        }
        public void CreatePost()
        {
            var thre = new Post();
            Console.WriteLine("Enter your user Id:");
            thre.User_Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the thread Id");
            thre.Thread_Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the comment:");
            thre.Comment = Console.ReadLine();
            _threadRepo.AddThread(thre);

        }
        public void UpdatePost(SqlitePostRepository prepo)
        {
            Console.WriteLine("Enter post Id");
            var pId = int.Parse(Console.ReadLine());
            var p = prepo.GetPostById(pId);
            Console.WriteLine("make a new comment:");
            p.Comment = Console.ReadLine();
            _postRepo.Create(p);
        }
        public void DeletePost(SqlitePostRepository prepo)
        {
            Console.WriteLine("Enter the post Id to delete a post");
            var pId = int.Parse(Console.ReadLine());
            var p = prepo.GetPostById(pId);
            _postRepo.Delete(p);
        }


        private static void PrintaThread(Thread thre)
        {
            Console.WriteLine(thre.Content);
        }
    }
}

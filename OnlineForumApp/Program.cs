using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using ForumLibrary;

namespace OnlineForumApp
{
    class Program
    {
        private static SqliteThreadRepository _threadRepo = new SqliteThreadRepository();
        private static SqliteUserRepository _userRepo = new SqliteUserRepository();
        private static SqlitePostRepository _postRepo = new SqlitePostRepository();
        
        static void Main(string[] args)
        {

             int input;
            do
            {
                Console.WriteLine("ONLINE DISUSSION FORUM");
                Console.WriteLine("*******************************************************************************************");
                Console.WriteLine("The currently trending topics are: ");
                PrintThread();
                Console.WriteLine("*******************************************************************************************");
                Console.WriteLine("FEW OPTIONS TO USE THE FORUM");
                Console.WriteLine("1. To create a new thread");
                Console.WriteLine("2.To view the thread with its related post");
                Console.WriteLine("3.To create a post/comment on a thread");
                
                Console.WriteLine("4.To delete a post");
                Console.WriteLine("5.To view user ");
                Console.WriteLine("6.To exit");
                input = int.Parse(Console.ReadLine());
                Console.WriteLine("*************************************************************************************************");
                switch (input)
                 
                {
                    case 1:
                        
                        CreateThread();
                        break;

                    case 2:
                                               
                        ThreadwithPost(_postRepo,_threadRepo);
                        break;
                    case 3:
                         CreatePost();
                        break;
                    
                    case 4:
                       
                        DeletePost(_postRepo);
                        break;
                    case 5:
                        UserList();
                        break;
                    case 6:
                        break;

                }



            }
            while (input < 6);


        }
        static void PrintThread()
        {
            var thread = _threadRepo.GetThreads();
            foreach (var thre in thread)
            {
                PrintaThread(thre);
            }
        }
       
        static void UserList()
        {
            var user = _userRepo.GetUsers();
            foreach(var ut in user)
            {
                Console.WriteLine(ut.Name);
            }
        }
        static void CreateThread()
        {
            var thre = new Thread();
            Console.WriteLine("Enter your user Id:");
            thre.User_Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a content for the thread:");
            thre.Content = Console.ReadLine();
            _threadRepo.AddThread(thre);
        }
        static void ThreadwithPost(SqlitePostRepository prepo, SqliteThreadRepository trepo)
        {
            Console.WriteLine("Enter the thread Id");
            int threadId = int.Parse(Console.ReadLine());
            var mthread = trepo.GetbyId(threadId);

            var tpost = prepo.WithThread(mthread);
            foreach (var tp in tpost)
            {
                Console.WriteLine(tp.Comment);
            }
        }



        static void CreatePost()
        {
            var post = new Post();
            Console.WriteLine("Enter your user Id:");
            post.User_Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the thread Id");
            post.Thread_Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the comment:");
            post.Comment = Console.ReadLine();
            _postRepo.Create(post);
        }


       
        static void DeletePost(SqlitePostRepository prepo)
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

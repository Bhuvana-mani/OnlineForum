using System;
using System.Collections.Generic;
using System.Text;

namespace ForumLibrary
{
    public class Thread
    {
        private int _id = -1;
        public int Thread_Id
        {
            get { return _id; }
            set { if (_id == -1) _id = value; }
        }
        public string Content { get; set; }
        public int User_Id { get; set; }
        //public List<Post> Posts { get; set; } = new List<Post>();
        public List<User> Users { get; set; } = new List<User>();
    }
}

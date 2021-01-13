using System;
using System.Collections.Generic;
using System.Text;

namespace ForumLibrary
{
    public class Post
    {
        private int _id = -1;
        public int Post_Id
        {
            get { return _id; }
            set { if (_id == -1) _id = value; }
        }
        public string Comment { get; set; }
        public int User_Id { get; set; }
        public int Thread_Id { get; set; }
        
    }
}

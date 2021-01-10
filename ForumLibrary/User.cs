using System;
using System.Collections.Generic;
using System.Text;

namespace ForumLibrary
{
    public class User
    {
        private int _id = -1;
        public int User_Id
        {
            get { return _id; }
            set { if (_id == -1) _id = value; }
        }
        public string Name { get; set; }
        public string Email_Address { get; set; }
        public List<Thread> Threads { get; set; } = new List<Thread>();
    }
}

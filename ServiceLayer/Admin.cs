using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public class Admin : User
    {
        public Admin(string userName, string password) : base(userName, password)
        {

        }
    }
}

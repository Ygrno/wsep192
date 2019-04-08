using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    class Admin : User
    {
        public Admin(string user_name, string password) : base(user_name, password)
        {

        }
    }
}

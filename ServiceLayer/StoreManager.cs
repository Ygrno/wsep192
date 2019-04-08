using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    class StoreManager : StoreOwner
    {
        public StoreManager(string user_name, string password) : base(user_name, password)
        {
        }
    }
}

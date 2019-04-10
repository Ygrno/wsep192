﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public class User
    {
        private String name;
        private String user_name, password;
        

        public User(String user_name, String password)
        {
            this.user_name = user_name;
            this.password = password;

        }

        public String getName()
        {
            return name;
        }



        public String getUserName()
        {
            return this.user_name;
        }

        public String getPassword()
        {
            return this.password;
        }

        public void logOut()
        {

        }

        public void openStore()
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ServiceLayer
{
    public class Product
    {

        public Product(string name, int price, string storeName)
        {
            this.name = name;
            this.price = price;
            this.storeName = storeName;
        }

        public String name { get; set; }
        public int price { get; set; }
        public int id { get; set; }

        public string storeName { get; set; }

        public string category;

        public string getCategory()
        {
            return category;
        }

        public void setCategory(string category)
        {
            this.category = category;
        }

    }
}

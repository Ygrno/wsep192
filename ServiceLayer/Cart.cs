using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public class Cart
    {
        private List<Product> products;
        public Cart()
        {
            products = new List<Product>();

        }

        public List<Product> getProducts()
        {
            return this.products;
        }
    }
}

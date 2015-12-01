using MVCYoubay2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCYoubay2.Helpers
{
    public class Item
    {
        public int Quantity { get; set; }
        private int _ProduitId;

        public t_product Product = null;
        public t_product Prod
        {
            get
            {

                return Product;
            }
            set
            {
                Product = value;
            }
        }

        public string Description
        {
            get { return Product.productDescription; }
        }

        public float UnitPrice
        {
            get { return Product.sellerPrice; }
        }

        public float TotalPrice
        {
            get
            {

                return Product.sellerPrice * Quantity;
            }
        }

        public Item(t_product p)
        {
            this.Prod = p;
        }

        public bool Equals(Item item)
        {
            return item.Prod.productId == this.Prod.productId;
        }

    }
}
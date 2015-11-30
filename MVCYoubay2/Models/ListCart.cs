using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCYoubay2.Models
{
    public class ListCart
    {
        public int ListCardId { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public int ProductId { get; set; }
        public virtual t_product Product { get; set; }

        public int Quantity { get; set; }

        public float TotalPrice { get; set; }

        public ListCart(Cart c , t_product p , int q , float px)
        {
            this.Cart = c;
            this.Product = p;
            this.Quantity = q;
            this.TotalPrice = px;   
        }
    }
}
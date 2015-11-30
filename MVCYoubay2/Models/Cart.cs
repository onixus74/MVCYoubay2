using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCYoubay2.Models
{
    public class Cart
    {
        public Cart()
        {

        }
        public int CartId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
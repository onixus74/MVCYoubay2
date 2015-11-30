using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCYoubay2.Models
{
    public partial class t_historyofviews
    {
        [Key]
        public long buyerId { get; set; }
        public long productId { get; set; }
        public System.DateTime theDate { get; set; }
        public Nullable<int> client { get; set; }
        public string comment { get; set; }
        public virtual t_product t_product { get; set; }
        public virtual t_user t_user { get; set; }
    }
}

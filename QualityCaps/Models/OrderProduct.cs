namespace QualityCaps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderProduct
    {
        [Key, Column(Order = 0)]
        [Required]
        public string OrderID { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public string ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

namespace QualityCaps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ProductColor
    {
        [Key, Column(Order = 0)]
        [Required]
        public string ProductID { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public string ColorID { get; set; }

        [Required]
        public int QuantityInStock { get; set; }


        public string ImageUrl { get; set; }
    
        public virtual Color Color { get; set; }
        public virtual Product Product { get; set; }
    }
}

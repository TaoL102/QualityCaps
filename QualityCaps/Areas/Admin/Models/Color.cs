namespace QualityCaps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Color
    {
        public Color()
        {
            this.ProductColors = new HashSet<ProductColor>();
        }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ColorID { get; set; }

        [Required]
        public string ColorName { get; set; }

        [Required]
        public string RGBCode { get; set; }
    
        public virtual ICollection<ProductColor> ProductColors { get; set; }
    }
}

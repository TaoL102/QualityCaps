namespace QualityCaps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
    
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CategoryID { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}

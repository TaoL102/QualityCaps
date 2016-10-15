namespace QualityCaps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product
    {
        public Product()
        {           
            this.ProductColors = new HashSet<ProductColor>();
        }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "#")]
        public string ProductID { get; set; }

        [Required]
        public string SupplierID { get; set; }

        [Required]
        public string CategoryID { get; set; }

        [Required]
        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Display(Name = "GST(%)")]
        public double GstPercentage { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    
        public virtual Category Category { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
    }
}

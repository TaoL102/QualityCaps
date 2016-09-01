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
            this.OrderProducts = new HashSet<OrderProduct>();
            this.ProductColors = new HashSet<ProductColor>();
        }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ProductID { get; set; }

        [Required]
        public string SupplierID { get; set; }

        [Required]
        public string CategoryID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }


        public string Discription { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
    }
}

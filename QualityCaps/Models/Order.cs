namespace QualityCaps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Order
    {
        public Order()
        {
            this.OrderProducts = new HashSet<OrderProduct>();
        }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OrderID { get; set; }

        [Required]
        public string CustomerID { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Gst { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal GrandTotal { get; set; }

        [Required]
        public virtual Customer Customer { get; set; }

        [Required]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}

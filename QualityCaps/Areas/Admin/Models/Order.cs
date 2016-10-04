using System.Linq;

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
        [Display(Name = "Order #")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OrderID { get; set; }

        [Required]
        [Display(Name = "Customer #")]
        public string CustomerID { get; set; }

        [Required]
        [Display(Name = "Shipping Status")]
        public string OrderStatusID { get; set; }

        [Required]
        [Display(Name = "Order placed")]
        public DateTime OrderDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Sub Total")]
        public decimal SubTotal { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "GST")]
        public decimal Gst { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Total")]
        public decimal GrandTotal
        {
            get { return SubTotal + Gst; }
            set {}
        }

        public virtual Customer Customer { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}

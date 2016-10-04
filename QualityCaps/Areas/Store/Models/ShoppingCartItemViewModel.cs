using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QualityCaps.Models
{
    public class ShoppingCartItemViewModel
    {

        public string ProductID { get; set; }
        public string ColorID { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public double GstPercentage { get; set; }

        public int Quantity { get; set; }
        public decimal TotalPrice => Convert.ToDecimal( UnitPrice * Quantity);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QualityCaps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderStatus
    {

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OrderStatusID { get; set; }

        [Required]
        public string StatusName { get; set; }

    }
}
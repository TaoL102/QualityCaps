namespace QualityCaps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Validations;

    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }


        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Phone]
        [ValidatePhoneNumber]
        [Display(Name = "Phone(Home)")]
        public string PhoneHome { get; set; }

        [Phone]
        [Display(Name = "Phone(Work)")]
        public string PhoneWork { get; set; }

        [Phone]
        [Display(Name = "Phone(Mobile)")]
        public string PhoneMobile { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

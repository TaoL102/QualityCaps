namespace QualityCaps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Validations;

    public partial class Supplier
    {
        public Supplier()
        {
            this.Products = new HashSet<Product>();
        }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SupplierID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Phone]
        [ValidatePhoneNumber]
        [Display(Name = "Phone(Home)")]
        public string PhoneHome { get; set; }

        [Phone]
        [ValidatePhoneNumber]
        [Display(Name = "Phone(Work)")]
        public string PhoneWork { get; set; }

        [Phone]
        [ValidatePhoneNumber]
        [Display(Name = "Phone(Mobile)")]
        public string PhoneMobile { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

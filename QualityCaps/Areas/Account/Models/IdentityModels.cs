using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QualityCaps.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [Display(Name = "Is Account Disabled")]
        public bool IsAccDisabled { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
         

        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Modify the table name to "Account" and id to "AccountID"
            modelBuilder.Entity<ApplicationUser>().ToTable("Accounts").Property(p => p.Id).HasColumnName("AccountID");

        }

        public System.Data.Entity.DbSet<QualityCaps.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<QualityCaps.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<QualityCaps.Models.Color> Colors { get; set; }

        public System.Data.Entity.DbSet<QualityCaps.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<QualityCaps.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<QualityCaps.Models.ProductColor> ProductColors { get; set; }

        public System.Data.Entity.DbSet<QualityCaps.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<QualityCaps.Models.OrderProduct> OrderProducts { get; set; }

        public System.Data.Entity.DbSet<QualityCaps.Models.OrderStatus> OrderStatus { get; set; }
    }
}
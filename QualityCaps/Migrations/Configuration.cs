using QualityCaps.Models;

namespace QualityCaps.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QualityCaps.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QualityCaps.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            // ORDERSTATUS
            context.OrderStatus.AddOrUpdate(o=>o.OrderStatusID,
                new OrderStatus()
                {
                    OrderStatusID = "Status001",
                    StatusName = "WAITING",
                },
                new OrderStatus()
                {
                    OrderStatusID = "Status002",
                    StatusName = "SHIPPED",
                }
                );

            // CATEGORY
            context.Categories.AddOrUpdate(c => c.CategoryID,
                new Category()
                {
                    CategoryID = "Category001",
                    CategoryName = "Men's Caps",
                },
                new Category()
                {
                    CategoryID = "Category002",
                    CategoryName = "Women's Caps",
                },
                new Category()
                {
                    CategoryID = "Category003",
                    CategoryName = "Children's Caps",
                }
                );

            // SUPPLIERS
            context.Suppliers.AddOrUpdate(s => s.SupplierID,
                new Supplier()
                {
                    SupplierID = "Supplier001",
                    Email = "CONTACT@NEWERA.COM",
                    Name = "NEW ERA",
                    PhoneHome = "02102112345",
                    PhoneMobile = "02102112345",
                    PhoneWork = "02102112345"
                },
                new Supplier()
                {
                    SupplierID = "Supplier002",
                    Email = "CONTACT@Kangol.COM",
                    Name = "Kangol",
                    PhoneHome = "02102112345",
                    PhoneMobile = "02102112345",
                    PhoneWork = "02102112345"
                },
                new Supplier()
                {
                    SupplierID = "Supplier003",
                    Email = "CONTACT@Barts.COM",
                    Name = "Barts",
                    PhoneHome = "02102112345",
                    PhoneMobile = "02102112345",
                    PhoneWork = "02102112345"
                },
                new Supplier()
                {
                    SupplierID = "Supplier004",
                    Email = "CONTACT@Stetson.COM",
                    Name = "Stetson",
                    PhoneHome = "02102112345",
                    PhoneMobile = "02102112345",
                    PhoneWork = "02102112345"
                }


                );

            // COLORS
            context.Colors.AddOrUpdate(c => c.ColorID,
                new Color()
                {
                    ColorID = "313767",
                    ColorName = "BLUE",
                    RGBCode = "#313767"
                },
                new Color()
                {
                    ColorID = "AB0114",
                    ColorName = "RED",
                    RGBCode = "#AB0114"
                },
                new Color()
                {
                    ColorID = "2A292A",
                    ColorName = "BLACK",
                    RGBCode = "#2A292A"
                },
                new Color()
                {
                    ColorID = "6F7B87",
                    ColorName = "DENIM",
                    RGBCode = "#6F7B87"
                },
                new Color()
                {
                    ColorID = "C8C3B0",
                    ColorName = "BEIGE",
                    RGBCode = "#C8C3B0"
                },
                new Color()
                {
                    ColorID = "B7B7B7",
                    ColorName = "GREY",
                    RGBCode = "#B7B7B7"
                },
                new Color()
                {
                    ColorID = "554840",
                    ColorName = "BROWN",
                    RGBCode = "#554840"
                }




            );


            // PRODUCTS
            context.Products.AddOrUpdate(p => p.ProductID,
                new Product()
                {
                    ProductID = "37588",
                    SupplierID = "Supplier001",
                    CategoryID = "Category001",
                    ProductName = "9FORTY League Basic Yankees Cap",
                    UnitPrice = Convert.ToDecimal(39.95),
                    GstPercentage = 15,
                    Description = @"The solid - coloured baseball cap from the 9FORTY series by New Era goes back to its sports roots and impresses with a clean look.The trendy peak cap is only decorated with the embroidered New York Yankees logo and a discreet brand embroidery on the side."
                },
                new Product()
                {
                    ProductID = "38041",
                    SupplierID = "Supplier002",
                    CategoryID = "Category001",
                    ProductName = "Denim Flexfit Baseball Cap",
                    UnitPrice = Convert.ToDecimal(29.95),
                    GstPercentage = 15,
                    Description = @"This elastic peaked cap from Kangol comes in a trendy denim look. The embroidered brand logo on the discreetly reinforced front and the Kangol label sewn on the closed back complete this casual baseball cap with stitched eyelets."
                },
                new Product()
                {
                    ProductID = "36136",
                    SupplierID = "Supplier001",
                    CategoryID = "Category001",
                    ProductName = "Clean Trucker Mesh Cap",
                    UnitPrice = Convert.ToDecimal(24.90),
                    GstPercentage = 15,
                    Description = @"This New Era cap from the popular 39Thirty collection features a soft mesh back and two foam front panels with oversized embroidered raised team logo."
                },
                new Product()
                {
                    ProductID = "42647",
                    SupplierID = "Supplier003",
                    CategoryID = "Category001",
                    ProductName = "Active Winter Sports Cap",
                    UnitPrice = Convert.ToDecimal(24.99),
                    GstPercentage = 15,
                    Description = @"The integrated elastic fitting with size adjustable plastic stopper at the back of the head makes sure this comfortable winter cap from Barts fits perfectly. The wearer of this innovative peaked cap will be pampered with warmth and comfort thanks to the windproof ear and neck protection, as well as the full lining of fluffy fleece."
                },
                new Product()
                {
                    ProductID = "34192",
                    SupplierID = "Supplier004",
                    CategoryID = "Category001",
                    ProductName = "Ducor Sun Guard Cap",
                    UnitPrice = Convert.ToDecimal(39),
                    GstPercentage = 15,
                    Description = @"Original stonewashed look for this classic, lightweight baseball cap. Its sun protection UV 40 allows you to be exposed to the sunshine fourty times longer than you normally could without burning. The skin-friendly organic cotton guarantees maximum wearing comfort."
                }

                ,
                new Product()
                {
                    ProductID = "43334",
                    SupplierID = "Supplier004",
                    CategoryID = "Category001",
                    ProductName = "Gosper Cap with Leather Peak",
                    UnitPrice = Convert.ToDecimal(49),
                    GstPercentage = 15,
                    Description = @"Velvety-soft leather on the upper side of the peak tames the striking army cap from Stetson. Apart from this, the sporty and rough urban cap features textured cotton and has an integrated UV filter."
                },
                new Product()
                {
                    ProductID = "42679",
                    SupplierID = "Supplier004",
                    CategoryID = "Category001",
                    ProductName = "Plano Nubuck Baseball Cap by Stetson",
                    UnitPrice = Convert.ToDecimal(49),
                    GstPercentage = 15,
                    Description = @"The pure cotton with a textured, woven structure is a sporty contrast to the velvety soft nubuck leather peak upper. This combination gives the fully enclosed baseball cap from Stetson an elegant touch. Skin-friendly and breathable properties, stitched ventilation eyelets and an integrated UV filter fully equip this high quality baseball cap for sunny days."
                },
                new Product()
                {
                    ProductID = "46411",
                    SupplierID = "Supplier001",
                    CategoryID = "Category001",
                    ProductName = "9FIFTY Patch Dodgers Cap",
                    UnitPrice = Convert.ToDecimal(37.95),
                    GstPercentage = 15,
                    Description = @"This baseball cap with circular retro logo of the Los Angeles Dodgers on the front will win you over with its solid design. This flat brimmed cap from trendy brand New Era features a reinforced front and typical straight peak. This snapback cap is open at the back and the press studs ensure perfect fit and optimum comfort."
                },
                new Product()
                {
                    ProductID = "44098",
                    SupplierID = "Supplier004",
                    CategoryID = "Category001",
                    ProductName = "Datto Winter Army Cap",
                    UnitPrice = Convert.ToDecimal(49.95),
                    GstPercentage = 15,
                    Description = @"With a warm fleece lining, this robust, coated cotton army cap in a washed leather-effect from Stetson is well prepared for the colder months. Perfectly coordinated details such as eyelets and brand embroidery make the striking cap what it is - unique! With factor 40 sun protection, the cap provides effective protection against autumn and winter sun."
                },
                new Product()
                {
                    ProductID = "44066",
                    SupplierID = "Supplier002",
                    CategoryID = "Category001",
                    ProductName = "Championship Army Cap Flexfit",
                    UnitPrice = Convert.ToDecimal(39.95),
                    GstPercentage = 15,
                    Description = @"The patented, extremely elastic Flexfit lining band makes this army cap from Kangol with its timeless cut incredibly comfortable. Two embroidered ventilation eyelets on each side of the cap keep your head at a pleasant temperature."
                }


            );

            context.ProductColors.AddOrUpdate(pc => new { pc.ProductID, pc.ColorID },
                new ProductColor()
                {
                    ProductID = "37588",
                    ColorID = "AB0114",
                    ImageUrl = "37588_f3.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "37588",
                    ColorID = "313767",
                    ImageUrl = "37588_f2.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "37588",
                    ColorID = "2A292A",
                    ImageUrl = "37588_f4.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "38041",
                    ColorID = "6F7B87",
                    ImageUrl = "38041p.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "36136",
                    ColorID = "2A292A",
                    ImageUrl = "36136_f4.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "42647",
                    ColorID = "2A292A",
                    ImageUrl = "42647_f4.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "34192",
                    ColorID = "C8C3B0",
                    ImageUrl = "34192_f15.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "43334",
                    ColorID = "C8C3B0",
                    ImageUrl = "43334_f15.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "42679",
                    ColorID = "C8C3B0",
                    ImageUrl = "42679_f15.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "46411",
                    ColorID = "B7B7B7",
                    ImageUrl = "46411_f13.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "44098",
                    ColorID = "554840",
                    ImageUrl = "44098_f11.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "44098",
                    ColorID = "2A292A",
                    ImageUrl = "44098_f4.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "44066",
                    ColorID = "313767",
                    ImageUrl = "44066_f2.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "44066",
                    ColorID = "2A292A",
                    ImageUrl = "44066_f4.jpg",
                    QuantityInStock = 50
                },
                new ProductColor()
                {
                    ProductID = "44066",
                    ColorID = "B7B7B7",
                    ImageUrl = "44066_f13.jpg",
                    QuantityInStock = 50
                }

                );
        }
    }
}

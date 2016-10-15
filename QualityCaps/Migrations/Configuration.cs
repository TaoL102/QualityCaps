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
            context.OrderStatus.AddOrUpdate(o => o.OrderStatusID,
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
                },
                new Supplier()
                {
                    SupplierID = "Supplier005",
                    Email = "CONTACT@Djinns.COM",
                    Name = "Djinns",
                    PhoneHome = "02102112345",
                    PhoneMobile = "02102112345",
                    PhoneWork = "02102112345"
                },
                new Supplier()
                {
                    SupplierID = "Supplier006",
                    Email = "CONTACT@Seeberger.COM",
                    Name = "Seeberger",
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
                , new Color() { ColorID = "F94D85", ColorName = "ROSE", RGBCode = "#F94D85" }
, new Color() { ColorID = "04894E", ColorName = "GREEN", RGBCode = "#04894E" }
, new Color() { ColorID = "F8512E", ColorName = "ORANGE", RGBCode = "#F8512E" }




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

                , new Product() { ProductID = "45374", SupplierID = "Supplier005", CategoryID = "Category003", ProductName = "HFT Buckle Linen Trucker Cap ", UnitPrice = Convert.ToDecimal(24.99), GstPercentage = 15, Description = "With the structure divided over the front and peak, the company logo and the velvety soft underside of the peak, this baseball cap from Djinns is a real highlight for your outfit. This trendy mesh cap features an airy mesh section at the back and a curved peak. The trucker cap is open at the back and press studs ensure optimum fit." }
, new Product() { ProductID = "43122", SupplierID = "Supplier005", CategoryID = "Category003", ProductName = "5 Panel Oxford Dots Cap", UnitPrice = Convert.ToDecimal(24.99), GstPercentage = 15, Description = "The entire head section of this trendy 5 panelled cap from Djinns is decorated with a dotty pattern, whilst the peak impresses with a soft velour upper.This trendy hat’s pure cotton, a padded lining band and stitched air holes guarantee complete comfort while you stand out from the crowd." }
, new Product() { ProductID = "45034", SupplierID = "Supplier003", CategoryID = "Category003", ProductName = "Flamingo Kids Baseball Cap", UnitPrice = Convert.ToDecimal(19.99), GstPercentage = 15, Description = "The Barts baseball cap for kid’s features cheerful and yet subtle polka dots. Its large peak extends out over the face, protecting from pesky rays of sun. The 100% cotton fabric and embroidered ventilation eyelets allow plenty of pleasantly fresh air to circulate around your head. The fashionable cap has a bow at the back, allowing the size to be adjusted." }
, new Product() { ProductID = "46336", SupplierID = "Supplier003", CategoryID = "Category003", ProductName = "Spandex Kids Flexfit Cap", UnitPrice = Convert.ToDecimal(9.95), GstPercentage = 15, Description = "Sportiness is the trump card of this no-frills baseball cap for children. The simple design comes in lots of great colours. The large visor protects from the sun, while plenty of cotton in the material blend ensures the cap is comfortable to wear. The stretchy cap can be worn during any activity and both boys and girls like it." }
, new Product() { ProductID = "36032", SupplierID = "Supplier003", CategoryID = "Category003", ProductName = "Kid Baseball Cap", UnitPrice = Convert.ToDecimal(9.95), GstPercentage = 15, Description = "Standing still is impossible with this baseball cap for little rascals. Made from pure cotton, it is extremely comfortable to wear." }
, new Product() { ProductID = "45685", SupplierID = "Supplier001", CategoryID = "Category002", ProductName = "Essential Fabric Mix Cap", UnitPrice = Convert.ToDecimal(29.99), GstPercentage = 15, Description = "This baseball cap with head section made of skin-friendly cotton has a simple design but is timelessly classy. This flat brimmed cap from trendy brand New Era features a reinforced front and typical straight peak. This snapback cap is open at the back and the press studs ensure perfect fit and optimum comfort." }
, new Product() { ProductID = "33285", SupplierID = "Supplier006", CategoryID = "Category002", ProductName = "Ansali Straw Visor Cap", UnitPrice = Convert.ToDecimal(35.95), GstPercentage = 15, Description = "Creative combination of straw visor and lightweight bandana. Knot it your way! Comfortable, elasticized back for perfect fit." }
, new Product() { ProductID = "45648", SupplierID = "Supplier004", CategoryID = "Category002", ProductName = "Texas Wool Uni Gatsby Cap", UnitPrice = Convert.ToDecimal(69), GstPercentage = 15, Description = "An exceptional wool blend was formed into a tight knit material for this form-fitting flat cap from Stetson, making it cosy and warm to wear. Visually, the knitted hat has a plain-coloured design which allows it to adapt flexibly to elegant and casual outfits alike. A welcome sight wherever you go." }
, new Product() { ProductID = "70886", SupplierID = "Supplier004", CategoryID = "Category002", ProductName = "Rector Baseball Cap ", UnitPrice = Convert.ToDecimal(29), GstPercentage = 15, Description = "Convertible tour, beer garden or open-air workout: This classic unreinforced baseball cap from Stetson offers great comfort and style for all outdoor occasions. It provides a UPF of 40+ to protect you against harmful effects from the sun." }
, new Product() { ProductID = "44484", SupplierID = "Supplier003", CategoryID = "Category003", ProductName = "Mason Uni Kids Earflap Cap", UnitPrice = Convert.ToDecimal(24.99), GstPercentage = 15, Description = "This baseball cap from Barts not only protects your face from the sun’s rays but also warms your ears, thanks to its fold-down ear protection. This has a fluffy lining and can be attached to the side of the soft denim cap with a press stud." }




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
                , new ProductColor() { ProductID = "45374", ColorID = "B7B7B7", ImageUrl = "45374_f13.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "43122", ColorID = "2A292A", ImageUrl = "43122_7f4.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "43122", ColorID = "AB0114", ImageUrl = "43122_7f3.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "45034", ColorID = "313767", ImageUrl = "45034_f2.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "45034", ColorID = "F94D85", ImageUrl = "45034_f25.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "46336", ColorID = "C8C3B0", ImageUrl = "46336_f15.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "46336", ColorID = "04894E", ImageUrl = "46336_f39.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "46336", ColorID = "F8512E", ImageUrl = "46336_f54.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "36032", ColorID = "313767", ImageUrl = "36032_f2.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "45685", ColorID = "313767", ImageUrl = "45685_f2.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "45685", ColorID = "AB0114", ImageUrl = "45685_f3.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "45685", ColorID = "B7B7B7", ImageUrl = "45685_f13.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "33285", ColorID = "AB0114", ImageUrl = "33285_f3.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "33285", ColorID = "F94D85", ImageUrl = "33285_f84.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "33285", ColorID = "F8512E", ImageUrl = "33285_f54.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "33285", ColorID = "554840", ImageUrl = "33285_f11.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "45648", ColorID = "313767", ImageUrl = "45648_f2.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "45648", ColorID = "AB0114", ImageUrl = "45648_f3.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "45648", ColorID = "2A292A", ImageUrl = "45648_f16.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "70886", ColorID = "04894E", ImageUrl = "70886_f39.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "70886", ColorID = "F8512E", ImageUrl = "70886_f54.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "70886", ColorID = "AB0114", ImageUrl = "70886_f3.jpg", QuantityInStock = 50 }
, new ProductColor() { ProductID = "44484", ColorID = "313767", ImageUrl = "44484_f2.jpg", QuantityInStock = 50 }


                );
        }
    }
}

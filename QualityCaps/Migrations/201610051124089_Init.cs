namespace QualityCaps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.String(nullable: false, maxLength: 128),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.String(nullable: false, maxLength: 128),
                        SupplierID = c.String(nullable: false, maxLength: 128),
                        CategoryID = c.String(nullable: false, maxLength: 128),
                        ProductName = c.String(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        GstPercentage = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductColors",
                c => new
                    {
                        ProductID = c.String(nullable: false, maxLength: 128),
                        ColorID = c.String(nullable: false, maxLength: 128),
                        QuantityInStock = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => new { t.ProductID, t.ColorID })
                .ForeignKey("dbo.Colors", t => t.ColorID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.ColorID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorID = c.String(nullable: false, maxLength: 128),
                        ColorName = c.String(nullable: false),
                        RGBCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ColorID);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderID = c.String(nullable: false, maxLength: 128),
                        ProductID = c.String(nullable: false, maxLength: 128),
                        ColorID = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID, t.ColorID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.ProductColors", t => new { t.ProductID, t.ColorID }, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => new { t.ProductID, t.ColorID });
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.String(nullable: false, maxLength: 128),
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        OrderStatusID = c.String(nullable: false, maxLength: 128),
                        OrderDate = c.DateTime(nullable: false),
                        SubTotal = c.Decimal(nullable: false, storeType: "money"),
                        Gst = c.Decimal(nullable: false, storeType: "money"),
                        GrandTotal = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.OrderStatusID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        AccountID = c.String(nullable: false, maxLength: 128),
                        FirstMidName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneHome = c.String(),
                        PhoneWork = c.String(),
                        PhoneMobile = c.String(),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.String(nullable: false, maxLength: 128),
                        IsAccDisabled = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.AccountID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ExternalLoginAccounts",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Accounts", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AccountRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Accounts", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        OrderStatusID = c.String(nullable: false, maxLength: 128),
                        StatusName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderStatusID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        PhoneHome = c.String(),
                        PhoneWork = c.String(),
                        PhoneMobile = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleID)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.ProductColors", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", new[] { "ProductID", "ColorID" }, "dbo.ProductColors");
            DropForeignKey("dbo.Orders", "OrderStatusID", "dbo.OrderStatus");
            DropForeignKey("dbo.OrderProducts", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.AccountRoles", "UserId", "dbo.Accounts");
            DropForeignKey("dbo.ExternalLoginAccounts", "UserId", "dbo.Accounts");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Accounts");
            DropForeignKey("dbo.ProductColors", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.AccountRoles", new[] { "RoleId" });
            DropIndex("dbo.AccountRoles", new[] { "UserId" });
            DropIndex("dbo.ExternalLoginAccounts", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Accounts", "UserNameIndex");
            DropIndex("dbo.Customers", new[] { "AccountID" });
            DropIndex("dbo.Orders", new[] { "OrderStatusID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.OrderProducts", new[] { "ProductID", "ColorID" });
            DropIndex("dbo.OrderProducts", new[] { "OrderID" });
            DropIndex("dbo.ProductColors", new[] { "ColorID" });
            DropIndex("dbo.ProductColors", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropTable("dbo.Roles");
            DropTable("dbo.Suppliers");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.AccountRoles");
            DropTable("dbo.ExternalLoginAccounts");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Accounts");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Colors");
            DropTable("dbo.ProductColors");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}

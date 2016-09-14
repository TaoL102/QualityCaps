namespace QualityCaps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSupplierLastName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Suppliers", "LastName");
            DropColumn("dbo.Suppliers", "FirstMidName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "FirstMidName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Suppliers", "LastName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Suppliers", "Name");
        }
    }
}

namespace QualityCaps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
              RenameTable(name: "dbo.AccountRoles", newName: "Roles");
            RenameColumn(table: "dbo.Roles", name: "Id", newName: "RoleID");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "ExternalLoginAccounts");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "AccountRoles");
          
            
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Roles", name: "RoleID", newName: "Id");
            RenameTable(name: "dbo.Roles", newName: "AccountRoles");
            RenameTable(name: "dbo.AccountRoles", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.ExternalLoginAccounts", newName: "AspNetUserLogins");
        }
    }
}

namespace ETicaretWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderedBy_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "OrderedBy_Id");
            AddForeignKey("dbo.Orders", "OrderedBy_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "OrderedBy_Id" });
            DropColumn("dbo.Orders", "OrderedBy_Id");
        }
    }
}

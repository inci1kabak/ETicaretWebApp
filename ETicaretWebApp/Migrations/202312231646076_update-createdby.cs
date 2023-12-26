namespace ETicaretWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecreatedby : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Campgains", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Categories", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Orders", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Payments", new[] { "CreatedBy_Id" });
            DropIndex("dbo.ProductReviews", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Products", new[] { "CreatedBy_Id" });
            DropColumn("dbo.Campgains", "CreatedById");
            DropColumn("dbo.Categories", "CreatedById");
            DropColumn("dbo.Orders", "CreatedById");
            DropColumn("dbo.Payments", "CreatedById");
            DropColumn("dbo.ProductReviews", "CreatedById");
            DropColumn("dbo.Products", "CreatedById");
            RenameColumn(table: "dbo.Campgains", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.Categories", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.Orders", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.Payments", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.ProductReviews", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.Products", name: "CreatedBy_Id", newName: "CreatedById");
            AlterColumn("dbo.Campgains", "CreatedById", c => c.String(maxLength: 128));
            AlterColumn("dbo.Categories", "CreatedById", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "CreatedById", c => c.String(maxLength: 128));
            AlterColumn("dbo.Payments", "CreatedById", c => c.String(maxLength: 128));
            AlterColumn("dbo.ProductReviews", "CreatedById", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "CreatedById", c => c.String(maxLength: 128));
            CreateIndex("dbo.Campgains", "CreatedById");
            CreateIndex("dbo.Categories", "CreatedById");
            CreateIndex("dbo.Orders", "CreatedById");
            CreateIndex("dbo.Payments", "CreatedById");
            CreateIndex("dbo.ProductReviews", "CreatedById");
            CreateIndex("dbo.Products", "CreatedById");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "CreatedById" });
            DropIndex("dbo.ProductReviews", new[] { "CreatedById" });
            DropIndex("dbo.Payments", new[] { "CreatedById" });
            DropIndex("dbo.Orders", new[] { "CreatedById" });
            DropIndex("dbo.Categories", new[] { "CreatedById" });
            DropIndex("dbo.Campgains", new[] { "CreatedById" });
            AlterColumn("dbo.Products", "CreatedById", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductReviews", "CreatedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "CreatedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CreatedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "CreatedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Campgains", "CreatedById", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Products", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.ProductReviews", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.Payments", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.Orders", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.Categories", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.Campgains", name: "CreatedById", newName: "CreatedBy_Id");
            AddColumn("dbo.Products", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.ProductReviews", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.Payments", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.Campgains", "CreatedById", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CreatedBy_Id");
            CreateIndex("dbo.ProductReviews", "CreatedBy_Id");
            CreateIndex("dbo.Payments", "CreatedBy_Id");
            CreateIndex("dbo.Orders", "CreatedBy_Id");
            CreateIndex("dbo.Categories", "CreatedBy_Id");
            CreateIndex("dbo.Campgains", "CreatedBy_Id");
        }
    }
}

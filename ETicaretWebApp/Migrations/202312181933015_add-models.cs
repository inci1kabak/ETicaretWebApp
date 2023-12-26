namespace ETicaretWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campgains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CampgainName = c.String(maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        CreatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        CreatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderedById = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Email = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        CreatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentName = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        CreatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.ProductReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.Int(nullable: false),
                        Description = c.String(),
                        Point = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        CreatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        CreatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.CreatedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductReviews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductReviews", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductReviews", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Payments", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Campgains", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Products", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.ProductReviews", new[] { "CreatedBy_Id" });
            DropIndex("dbo.ProductReviews", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProductReviews", new[] { "ProductId" });
            DropIndex("dbo.Payments", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Orders", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Categories", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Campgains", new[] { "CreatedBy_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductReviews");
            DropTable("dbo.Payments");
            DropTable("dbo.Orders");
            DropTable("dbo.Categories");
            DropTable("dbo.Campgains");
        }
    }
}

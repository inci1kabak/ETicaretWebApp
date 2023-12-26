namespace ETicaretWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductReviews", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.ProductReviews", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductReviews", "ApplicationUserId", c => c.Int(nullable: false));
            DropColumn("dbo.ProductReviews", "UserId");
        }
    }
}

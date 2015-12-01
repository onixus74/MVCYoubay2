namespace MVCYoubay2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_product", "Seller_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.t_product", "Seller_Id");
            AddForeignKey("dbo.t_product", "Seller_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.t_product", "seller_youBayUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.t_product", "seller_youBayUserId", c => c.Long());
            DropForeignKey("dbo.t_product", "Seller_Id", "dbo.AspNetUsers");
            DropIndex("dbo.t_product", new[] { "Seller_Id" });
            DropColumn("dbo.t_product", "Seller_Id");
        }
    }
}

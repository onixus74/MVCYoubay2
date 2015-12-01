namespace MVCYoubay2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.t_product", "productImage", c => c.String());
            DropColumn("dbo.t_product", "productIWmage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.t_product", "productIWmage", c => c.String());
            DropForeignKey("dbo.Carts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Carts", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.t_product", "productImage");
            DropTable("dbo.Carts");
        }
    }
}

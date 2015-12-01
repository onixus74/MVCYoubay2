namespace MVCYoubay2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Category1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_product", "t_category_categoryId", c => c.Long());
            CreateIndex("dbo.t_product", "t_category_categoryId");
            AddForeignKey("dbo.t_product", "t_category_categoryId", "dbo.t_category", "categoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_product", "t_category_categoryId", "dbo.t_category");
            DropIndex("dbo.t_product", new[] { "t_category_categoryId" });
            DropColumn("dbo.t_product", "t_category_categoryId");
        }
    }
}

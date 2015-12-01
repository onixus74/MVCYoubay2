namespace MVCYoubay2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_product", "seller_youBayUserId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.t_product", "seller_youBayUserId");
        }
    }
}

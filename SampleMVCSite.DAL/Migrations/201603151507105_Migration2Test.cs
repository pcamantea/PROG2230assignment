namespace SampleMVCSite.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        BasketID = c.Guid(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BasketID);
            
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        BasketItemID = c.Int(nullable: false, identity: true),
                        BasketID = c.Guid(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasketItemID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Baskets", t => t.BasketID, cascadeDelete: true)
                .Index(t => t.BasketID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "BasketID", "dbo.Baskets");
            DropForeignKey("dbo.BasketItems", "ProductID", "dbo.Products");
            DropIndex("dbo.BasketItems", new[] { "ProductID" });
            DropIndex("dbo.BasketItems", new[] { "BasketID" });
            DropTable("dbo.BasketItems");
            DropTable("dbo.Baskets");
        }
    }
}

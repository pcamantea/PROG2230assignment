namespace SampleMVCSite.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2Test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductDescription", c => c.String());
            DropColumn("dbo.Products", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Description", c => c.String());
            DropColumn("dbo.Products", "ProductDescription");
        }
    }
}

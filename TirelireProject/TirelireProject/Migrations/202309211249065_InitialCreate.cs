namespace TirelireProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Product", "ProductDescription", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.Product", "ProductHeight", c => c.String(nullable: false));
            AddColumn("dbo.Product", "ProductWidth", c => c.String(nullable: false));
            AddColumn("dbo.Product", "ProductWeight", c => c.String(nullable: false));
            AddColumn("dbo.Product", "ProductLength", c => c.String(nullable: false));
            AddColumn("dbo.Product", "ProductColor", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Product", "ProductCapacity", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Product", "ProductMaker", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Product", "ProductImage", c => c.Binary(nullable: false));
            AddColumn("dbo.Product", "ProductPrice", c => c.Single(nullable: false));
            DropColumn("dbo.Customer", "Role");
            DropColumn("dbo.Product", "product_name");
            DropColumn("dbo.Product", "product_description");
            DropColumn("dbo.Product", "product_height");
            DropColumn("dbo.Product", "product_width");
            DropColumn("dbo.Product", "product_weight");
            DropColumn("dbo.Product", "product_length");
            DropColumn("dbo.Product", "product_colour");
            DropColumn("dbo.Product", "product_capacity");
            DropColumn("dbo.Product", "product_maker");
            DropColumn("dbo.Product", "product_img");
            DropColumn("dbo.Product", "product_price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "product_price", c => c.Single(nullable: false));
            AddColumn("dbo.Product", "product_img", c => c.Binary(nullable: false));
            AddColumn("dbo.Product", "product_maker", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Product", "product_capacity", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Product", "product_colour", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Product", "product_length", c => c.String(nullable: false));
            AddColumn("dbo.Product", "product_weight", c => c.String(nullable: false));
            AddColumn("dbo.Product", "product_width", c => c.String(nullable: false));
            AddColumn("dbo.Product", "product_height", c => c.String(nullable: false));
            AddColumn("dbo.Product", "product_description", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.Product", "product_name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Customer", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "ProductPrice");
            DropColumn("dbo.Product", "ProductImage");
            DropColumn("dbo.Product", "ProductMaker");
            DropColumn("dbo.Product", "ProductCapacity");
            DropColumn("dbo.Product", "ProductColor");
            DropColumn("dbo.Product", "ProductLength");
            DropColumn("dbo.Product", "ProductWeight");
            DropColumn("dbo.Product", "ProductWidth");
            DropColumn("dbo.Product", "ProductHeight");
            DropColumn("dbo.Product", "ProductDescription");
            DropColumn("dbo.Product", "ProductName");
        }
    }
}

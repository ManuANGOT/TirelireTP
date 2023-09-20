namespace TirelireProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateTirelireProjectContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        Birthdate = c.DateTime(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        ProductDescription = c.String(nullable: false, maxLength: 1000),
                        ProductHeight = c.String(nullable: false),
                        ProductWidth = c.String(nullable: false),
                        ProductWeight = c.String(nullable: false),
                        ProductLength = c.String(nullable: false),
                        ProductColor = c.String(nullable: false, maxLength: 50),
                        ProductCapacity = c.String(nullable: false, maxLength: 50),
                        ProductMaker = c.String(nullable: false, maxLength: 50),
                        ProductImage = c.Binary(nullable: false),
                        ProductPrice = c.Single(nullable: false),
                        Product_Id = c.Int(),
                        ShoppingCart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .ForeignKey("dbo.ShoppingCart", t => t.ShoppingCart_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.ShoppingCart_Id);
            
            CreateTable(
                "dbo.ShoppingCart",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CartDate = c.DateTime(nullable: false),
                        CartProductAdded = c.Int(nullable: false),
                        CartProductCancelled = c.Int(nullable: false),
                        CartDetails = c.Int(nullable: false),
                        CartShipping = c.Int(nullable: false),
                        CartPriceHT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ShoppingCart_Id", "dbo.ShoppingCart");
            DropForeignKey("dbo.Product", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Customer", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.Product", new[] { "ShoppingCart_Id" });
            DropIndex("dbo.Product", new[] { "Product_Id" });
            DropIndex("dbo.Customer", new[] { "Customer_Id" });
            DropTable("dbo.ShoppingCart");
            DropTable("dbo.Product");
            DropTable("dbo.Customer");
        }
    }
}

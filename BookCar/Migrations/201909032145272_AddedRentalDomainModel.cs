namespace BookCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRentalDomainModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        car_Id = c.Int(nullable: false),
                        customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.car_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.customer_Id, cascadeDelete: true)
                .Index(t => t.car_Id)
                .Index(t => t.customer_Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "car_Id", "dbo.Cars");
            DropIndex("dbo.Rentals", new[] { "customer_Id" });
            DropIndex("dbo.Rentals", new[] { "car_Id" });
            DropTable("dbo.Cars");
            DropTable("dbo.Rentals");
        }
    }
}

namespace BookCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCarsdetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "carType", c => c.String(nullable: false));
            AddColumn("dbo.Cars", "releaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cars", "dateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cars", "numberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "numberInStock");
            DropColumn("dbo.Cars", "dateAdded");
            DropColumn("dbo.Cars", "releaseDate");
            DropColumn("dbo.Cars", "carType");
        }
    }
}

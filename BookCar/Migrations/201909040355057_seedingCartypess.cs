namespace BookCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingCartypess : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CarTypes(type) VALUES('Hatchback')");
            Sql("INSERT INTO CarTypes(type) VALUES('Sedan')");
            Sql("INSERT INTO CarTypes(type) VALUES('SUV')");
        }
        
        public override void Down()
        {
        }
    }
}

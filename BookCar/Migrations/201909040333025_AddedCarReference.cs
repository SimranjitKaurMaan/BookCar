namespace BookCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCarReference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "carTypeID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "carTypeID");
        }
    }
}

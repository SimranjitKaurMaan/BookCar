namespace BookCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBirthProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}

namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedPickUpDays : DbMigration
    {
        public override void Up()
        {
            Sql("SET Identity_Insert PickUpDays ON INSERT INTO dbo.PickUpDays (Id, Cost, Weeks, DayID) VALUES (1, 15.00, '3', 2)");
        }
        
        public override void Down()
        {
        }
    }
}

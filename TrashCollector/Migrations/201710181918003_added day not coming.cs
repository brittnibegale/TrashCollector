namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddaynotcoming : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PickUpDays", "day1", c => c.DateTime(nullable: false));
            AddColumn("dbo.PickUpDays", "day2", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PickUpDays", "day2");
            DropColumn("dbo.PickUpDays", "day1");
        }
    }
}

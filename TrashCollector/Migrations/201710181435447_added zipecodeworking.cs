namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedzipecodeworking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkerInfoes", "ZipcodeWorking", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkerInfoes", "ZipcodeWorking");
        }
    }
}

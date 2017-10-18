namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedworkerinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkerInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PickUpDayId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.PickUpDays", t => t.PickUpDayId, cascadeDelete: true)
                .Index(t => t.PickUpDayId)
                .Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkerInfoes", "PickUpDayId", "dbo.PickUpDays");
            DropForeignKey("dbo.WorkerInfoes", "AddressId", "dbo.Addresses");
            DropIndex("dbo.WorkerInfoes", new[] { "AddressId" });
            DropIndex("dbo.WorkerInfoes", new[] { "PickUpDayId" });
            DropTable("dbo.WorkerInfoes");
        }
    }
}

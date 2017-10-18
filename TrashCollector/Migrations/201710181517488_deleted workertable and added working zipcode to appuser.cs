namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedworkertableandaddedworkingzipcodetoappuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkerInfoes", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.WorkerInfoes", "PickUpDayId", "dbo.PickUpDays");
            DropIndex("dbo.WorkerInfoes", new[] { "PickUpDayId" });
            DropIndex("dbo.WorkerInfoes", new[] { "AddressId" });
            AddColumn("dbo.AspNetUsers", "Workingzipcode", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.WorkerInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkerInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ZipcodeWorking = c.String(),
                        PickUpDayId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropPrimaryKey("dbo.AspNetUsers");
            AlterColumn("dbo.AspNetUsers", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.AspNetUsers", "Workingzipcode");
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            CreateIndex("dbo.WorkerInfoes", "AddressId");
            CreateIndex("dbo.WorkerInfoes", "PickUpDayId");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkerInfoes", "PickUpDayId", "dbo.PickUpDays", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkerInfoes", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}

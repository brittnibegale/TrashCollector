namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixeddatabases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Zipcode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DayOfPickUp = c.String(),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Days");
            DropTable("dbo.Addresses");
        }
    }
}

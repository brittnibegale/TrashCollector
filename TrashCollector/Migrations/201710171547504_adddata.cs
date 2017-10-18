namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddata : DbMigration
    {
        public override void Up()
        {
            Sql("SET Identity_Insert Addresses ON INSERT INTO dbo.Addresses (Id, Street, City, Zipcode) VALUES (1, '1570 N Prospect Ave', 'Milwaukee', '53202')");
            
        }
        
        public override void Down()
        {
        }
    }
}

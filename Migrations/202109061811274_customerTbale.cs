namespace weRentvideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerTbale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        PhoneNo = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerModels");
        }
    }
}

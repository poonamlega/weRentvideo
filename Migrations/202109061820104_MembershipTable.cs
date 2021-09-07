namespace weRentvideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SignUpFees = c.Int(nullable: false),
                        DurationInMonths = c.Int(nullable: false),
                        DiscountRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MembershipModels");
        }
    }
}

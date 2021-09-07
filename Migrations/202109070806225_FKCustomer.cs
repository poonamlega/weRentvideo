namespace weRentvideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "MembershipFK", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerModels", "MembershipFK");
            AddForeignKey("dbo.CustomerModels", "MembershipFK", "dbo.MembershipModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerModels", "MembershipFK", "dbo.MembershipModels");
            DropIndex("dbo.CustomerModels", new[] { "MembershipFK" });
            DropColumn("dbo.CustomerModels", "MembershipFK");
        }
    }
}

namespace weRentvideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatypeIdChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerModels", "MembershipFK", "dbo.MembershipModels");
            DropIndex("dbo.CustomerModels", new[] { "MembershipFK" });
            DropPrimaryKey("dbo.MembershipModels");
            AlterColumn("dbo.CustomerModels", "MembershipFK", c => c.String(maxLength: 128));
            AlterColumn("dbo.MembershipModels", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.MembershipModels", "Id");
            CreateIndex("dbo.CustomerModels", "MembershipFK");
            AddForeignKey("dbo.CustomerModels", "MembershipFK", "dbo.MembershipModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerModels", "MembershipFK", "dbo.MembershipModels");
            DropIndex("dbo.CustomerModels", new[] { "MembershipFK" });
            DropPrimaryKey("dbo.MembershipModels");
            AlterColumn("dbo.MembershipModels", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CustomerModels", "MembershipFK", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.MembershipModels", "Id");
            CreateIndex("dbo.CustomerModels", "MembershipFK");
            AddForeignKey("dbo.CustomerModels", "MembershipFK", "dbo.MembershipModels", "Id", cascadeDelete: true);
        }
    }
}

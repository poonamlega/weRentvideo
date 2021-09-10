namespace weRentvideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameToMembership : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipModels", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipModels", "Name");
        }
    }
}

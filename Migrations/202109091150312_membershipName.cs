namespace weRentvideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membershipName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipModels", "MembershipName", c => c.String());
            DropColumn("dbo.MembershipModels", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipModels", "Name", c => c.String());
            DropColumn("dbo.MembershipModels", "MembershipName");
        }
    }
}

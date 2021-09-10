namespace weRentvideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieModels", "Genre", c => c.String());
            AddColumn("dbo.MovieModels", "NumberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieModels", "NumberInStock");
            DropColumn("dbo.MovieModels", "Genre");
        }
    }
}

namespace MovieDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTmdbId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "TmdbId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "TmdbId");
        }
    }
}

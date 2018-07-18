namespace MovieDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.MovieUserXrefs", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieUserXrefs", "IsDeleted");
            DropColumn("dbo.Movies", "IsDeleted");
        }
    }
}

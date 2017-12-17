namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "UserID", c => c.String());
        }
    }
}

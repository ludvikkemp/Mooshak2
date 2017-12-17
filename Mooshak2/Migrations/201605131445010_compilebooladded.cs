namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compilebooladded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "Compiled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "Compiled");
        }
    }
}

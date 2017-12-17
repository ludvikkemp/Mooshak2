namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasegroupsize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignments", "GroupSize", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignments", "GroupSize");
        }
    }
}

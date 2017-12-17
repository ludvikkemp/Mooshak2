namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MilestoneID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "MilestoneID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "MilestoneID");
        }
    }
}

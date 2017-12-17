namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inputoutput : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Milestones", "MilestoneInput1", c => c.String());
            AddColumn("dbo.Milestones", "MilestoneOutput1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Milestones", "MilestoneOutput1");
            DropColumn("dbo.Milestones", "MilestoneInput1");
        }
    }
}

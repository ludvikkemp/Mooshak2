namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class submissionlimit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Milestones", "SubmissionLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Milestones", "SubmissionLimit");
        }
    }
}

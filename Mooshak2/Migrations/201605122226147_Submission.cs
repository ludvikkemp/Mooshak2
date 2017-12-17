namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Submission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "UserID", c => c.String());
            AddColumn("dbo.Submissions", "SubmissionFileName", c => c.String());
            AddColumn("dbo.Submissions", "SubmissionPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "SubmissionPath");
            DropColumn("dbo.Submissions", "SubmissionFileName");
            DropColumn("dbo.Submissions", "UserID");
        }
    }
}

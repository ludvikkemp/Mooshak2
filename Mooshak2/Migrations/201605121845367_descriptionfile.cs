namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class descriptionfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignments", "DescriptionPath", c => c.String());
            AddColumn("dbo.Assignments", "DescriptionFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignments", "DescriptionFileName");
            DropColumn("dbo.Assignments", "DescriptionPath");
        }
    }
}

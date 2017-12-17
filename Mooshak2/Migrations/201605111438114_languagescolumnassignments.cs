namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class languagescolumnassignments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignments", "Languages", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignments", "Languages");
        }
    }
}

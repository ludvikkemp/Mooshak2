namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableIntInCourseID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "CourseID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "CourseID", c => c.Int(nullable: false));
        }
    }
}

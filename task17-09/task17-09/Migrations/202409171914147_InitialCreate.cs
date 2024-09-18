namespace TASK17_09.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AsignmentName = c.String(),
                        date = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teacher");
            DropTable("dbo.Student");
            DropTable("dbo.Assignment");
        }
    }
}

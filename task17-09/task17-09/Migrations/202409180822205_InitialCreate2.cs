namespace TASK17_09.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Assignment", newName: "Assignments");
            RenameTable(name: "dbo.Student", newName: "Students");
            RenameTable(name: "dbo.Teacher", newName: "Teachers");
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.StudentDetails",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentDetails", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.StudentDetails", new[] { "StudentId" });
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropTable("dbo.StudentDetails");
            DropTable("dbo.Courses");
            RenameTable(name: "dbo.Teachers", newName: "Teacher");
            RenameTable(name: "dbo.Students", newName: "Student");
            RenameTable(name: "dbo.Assignments", newName: "Assignment");
        }
    }
}

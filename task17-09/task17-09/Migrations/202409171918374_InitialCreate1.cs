namespace TASK17_09.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teacher", "Ages", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teacher", "Ages");
        }
    }
}

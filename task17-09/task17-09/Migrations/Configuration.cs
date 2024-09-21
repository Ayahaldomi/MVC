namespace TASK17_09.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TASK17_09.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TASK17_09.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            
                context.Students.AddOrUpdate(
                    s => s.StudentName,
                    new Models.Student { StudentName = "saer", Age = 19 },
                    new Models.Student { StudentName = "Orange", Age = 98 }
                );
            
        }
    }
}

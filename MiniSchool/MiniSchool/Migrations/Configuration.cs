namespace MiniSchool.Migrations
{
    using MiniSchool.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MiniSchool.Models.MiniSchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MiniSchool.Models.MiniSchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Subjects.AddOrUpdate(
             s => s.Name, // This is a unique property to avoid duplicates
             new Subject { Name = "Math" },
             new Subject { Name = "Science" },
             new Subject { Name = "History" });
        }
    }
}

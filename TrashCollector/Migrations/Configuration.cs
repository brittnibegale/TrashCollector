namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TrashCollector.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TrashCollector.Models.ApplicationDbContext context)
        {
            context.Day.AddOrUpdate(
                p => p.DayChoice,
                new Models.Day { DayChoice = "Monday" },
                new Models.Day { DayChoice = "Tuesday"},
                new Models.Day { DayChoice = "Wednesday"},
                new Models.Day { DayChoice = "Thursday" },
                new Models.Day { DayChoice = "Friday" },
                new Models.Day { DayChoice = "Saturday"},
                new Models.Day { DayChoice = "Sunday"}
                );
        

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

using BlogKolorWebService.Models;

namespace BlogKolorWebService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogKolorWebService.Models.PostContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogKolorWebService.Models.PostContex context)
        {

            context.Posts.Add(new Post()
            {
                Id = Guid.NewGuid().ToString(),
                Author = "Sebcza",
                Content = "Jakas tresc wpisu",
                Title = "Pierwsze zajecia"
            });
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

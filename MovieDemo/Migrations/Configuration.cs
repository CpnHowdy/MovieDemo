namespace MovieDemo.Migrations
{
    using MovieDemo.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieDemo.Models.MovieDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// This method will be called after migrating to the latest version.
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(MovieDemo.Models.MovieDbContext context)
        {
            using (var db = new MovieDbContext() )
            {
                // Guardians of the Galaxy II
                db.Movies.AddOrUpdate(new Movie
                {
                    ImdbId = "tt3896198",
                    CreatedDate = DateTime.UtcNow,
                    CreatedUser = "EF Seed Method",
                    UpdatedDate = null,
                    UpdatedUser = null
                });
            }
        }
    }
}

using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieDemo.Models
{
    public class MovieDbContext : IdentityDbContext<ApplicationUser>
    {
        public MovieDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static MovieDbContext Create()
        {
            return new MovieDbContext();
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieUserXref> MovieUsers { get; set; }
    }
}
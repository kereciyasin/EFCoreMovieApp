using EFCoreMovieApp.Infra.Entities;
using EFCoreMovieApp.Infra.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovieApp.Infra.Context
{
    public class MovieDbContext : DbContext
    {
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<ActorEntity> Actors { get; set; }
        public DbSet<DirectorEntity> Directors { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }

        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        public MovieDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ef");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieEntityConfiguration).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connStr = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connStr, options =>
            {
                options.CommandTimeout(5_000);
                options.EnableRetryOnFailure(maxRetryCount: 5);

            });


        }


    }
}

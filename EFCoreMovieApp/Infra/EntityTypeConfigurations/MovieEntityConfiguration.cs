using EFCoreMovieApp.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovieApp.Infra.EntityTypeConfigurations
{
    public class MovieEntityConfiguration : BaseEntityTypeConfiguration<MovieEntity>
    {
        public override void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.ToTable(name: "Movies", schema: "ef");

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(e => e.ViewCount)
                .HasDefaultValue(1)
                .HasColumnName("ViewCount");

            //One to many relation with DirectorEntity
            builder.HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId);

            //one to mantrelation with GenreEntity  
            builder.HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            //many to many relation with ActorEntity    
            builder.HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .UsingEntity(j => j.ToTable("MovieActors"));


            base.Configure(builder);

        }
    }
}

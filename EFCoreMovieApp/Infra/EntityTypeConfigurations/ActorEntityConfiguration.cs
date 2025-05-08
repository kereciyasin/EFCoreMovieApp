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
    public class ActorEntityConfiguration : BaseEntityTypeConfiguration<ActorEntity>
    {
        public override void Configure(EntityTypeBuilder<ActorEntity> builder)
        {
            builder.ToTable(name: "Actors", schema: "ef");

            //builder.HasMany(a => a.Movies)
            //    .WithMany(m => m.Actors)
            //    .UsingEntity(j => j.ToTable("MovieActors"));


            builder.Property(e => e.FirstName)
                .HasColumnName("FirstName")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.LastName)
                 .HasColumnName("LastName")
                .IsRequired()
                .HasMaxLength(100);
            base.Configure(builder);
        }
    }
}
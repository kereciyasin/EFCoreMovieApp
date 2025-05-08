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
    public class DirectorEntityConfiguration : BaseEntityTypeConfiguration<DirectorEntity>
    {
        public override void Configure(EntityTypeBuilder<DirectorEntity> builder)
        {
            builder.ToTable(name: "Directors", schema: "ef");


            // TODO: Movies relation
            // One to many relation with MovieEntity

            builder.HasMany(d => d.Movies)
                .WithOne(m => m.Director)
                .HasForeignKey(m => m.DirectorId);

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

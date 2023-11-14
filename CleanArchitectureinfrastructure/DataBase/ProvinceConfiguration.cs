using CleanArchitectureDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureInfrastructure.DataBase
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("provincias");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id_provincia");

            builder.Property(p => p.Name)
                .HasColumnName("nombre");

            builder.Property(p => p.Created)
                .HasColumnName("fecha_alta");

            builder.Property(p => p.Updated)
                .HasColumnName("fecha_modificacion");

            builder.Property(p => p.Deleted)
                .HasColumnName("fecha_baja");
        }
    }
}
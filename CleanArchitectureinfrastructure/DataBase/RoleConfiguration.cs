using CleanArchitectureDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureInfrastructure.DataBase
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .HasColumnName("id_rol");

            builder.Property(r => r.Name)
                .HasColumnName("nombre");

            builder.Property(r => r.IsDefault)
                .HasColumnName("es_predeterminado");

            builder.Property(r => r.Created)
                .HasColumnName("fecha_alta");

            builder.Property(r => r.Updated)
                .HasColumnName("fecha_modificacion");

            builder.Property(r => r.Deleted)
                .HasColumnName("fecha_baja");
        }
    }
}
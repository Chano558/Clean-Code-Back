using CleanArchitectureDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureInfrastructure.DataBase
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("usuarios");

            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserId)
                .HasColumnName("id_usuario");

            builder.Property(u => u.RoleId)
                .HasColumnName("id_rol");

            builder.HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);
        }
    }
}

using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("Ciudad");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.NombreCiudad)
        .HasColumnName("NombreCiudad")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(120);

        builder.HasOne(d => d.Departamento)
        .WithMany(d => d.Ciudades)
        .HasForeignKey(d => d.IdDepartamentoFK);
    }
}

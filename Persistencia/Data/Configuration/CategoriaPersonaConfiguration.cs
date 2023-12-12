
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class CategoriaPersonaConfiguration : IEntityTypeConfiguration<CategoriaPersona>
{
    public void Configure(EntityTypeBuilder<CategoriaPersona> builder)
    {
        builder.ToTable("CategoriaPersona");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.NombreCategoria)
        .HasColumnName("nombreCategoria")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(100);
    }
}

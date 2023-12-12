
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class DireccionPersonaConfiguration : IEntityTypeConfiguration<DireccionPersona>
{
    public void Configure(EntityTypeBuilder<DireccionPersona> builder)
    {
        builder.ToTable("DireccionPersona");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.Direccion)
        .HasColumnName("Direccion")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(250);

        builder.HasOne(d => d.Persona)
        .WithMany(d => d.DireccionPersonas)
        .HasForeignKey(d => d.IdPersonaFK);

        builder.HasOne(d => d.TipoDireccion)
        .WithMany(d => d.DireccionPersonas)
        .HasForeignKey(d => d.IdTDireccionFK);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("Persona");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.IdentificacionPersona)
        .HasColumnName("IdentificacionPersona")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(20);

        builder.HasIndex(d => d.IdentificacionPersona).IsUnique();

        builder.Property(d => d.Nombre)
        .HasColumnName("Nombre")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(120);

        builder.Property(d => d.FechaRegistro)
        .HasColumnName("FechaRegistro")
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(d => d.TipoPersona)
        .WithMany(d => d.Personas)
        .HasForeignKey(d => d.IdTPersonaFK);

        builder.HasOne(d => d.CategoriaPersona)
        .WithMany(d => d.Personas)
        .HasForeignKey(d => d.IdCategoriaFK);

        builder.HasOne(d => d.Ciudad)
        .WithMany(d => d.Personas)
        .HasForeignKey(d => d.IdCiudad);
    }
}

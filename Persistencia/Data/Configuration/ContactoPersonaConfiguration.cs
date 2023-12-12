
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistencia.Data.Configuration;

public class ContactoPersonaConfiguration : IEntityTypeConfiguration<ContactoPersona>
{
    public void Configure(EntityTypeBuilder<ContactoPersona> builder)
    {
        builder.ToTable("ContactoPersona");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.Descripcion)
        .HasColumnName("Descripcion")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(250);

        builder.HasOne(d => d.Persona)
        .WithMany(d => d.ContactoPersonas)
        .HasForeignKey(d => d.IdPersonaFK);

        builder.HasOne(d => d.TipoContacto)
        .WithMany(d => d.ContactoPersonas)
        .HasForeignKey(d => d.IdContactoFK);
    }
}


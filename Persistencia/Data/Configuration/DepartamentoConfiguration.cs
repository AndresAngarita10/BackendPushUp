

using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamento");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.NombreDep)
        .HasColumnName("NombreDep")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(60);

        builder.HasOne(d => d.Pais)
        .WithMany(d => d.Departamentos)
        .HasForeignKey(d => d.IdPaisFK);
    }
}

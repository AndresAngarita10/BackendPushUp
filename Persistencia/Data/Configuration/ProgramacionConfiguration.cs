using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
{
    public void Configure(EntityTypeBuilder<Programacion> builder)
    {
        builder.ToTable("Programacion");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.HasOne(d => d.Contrato)
        .WithMany(d => d.Programaciones)
        .HasForeignKey(d => d.IdContrato);

        builder.HasOne(d => d.Turno)
        .WithMany(d => d.Programaciones)
        .HasForeignKey(d => d.IdTurno);

        builder.HasOne(d => d.Empleado)
        .WithMany(d => d.Programaciones)
        .HasForeignKey(d => d.IdEmpleado);
    }
}

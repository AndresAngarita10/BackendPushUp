using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        builder.ToTable("Contrato");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.FechaContrato)
        .HasColumnName("FechaContrato")
        .HasColumnType("date")
        .IsRequired();
        
        builder.Property(d => d.FechaFin)
        .HasColumnName("FechaFin")
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(d => d.Cliente)
        .WithMany(d => d.ContratoClientes)
        .HasForeignKey(d => d.IdCliente);

        builder.HasOne(d => d.Empleado)
        .WithMany(d => d.ContratoEmpleados)
        .HasForeignKey(d => d.IdEmpleado);

    }
}

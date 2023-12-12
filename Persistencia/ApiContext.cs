using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;
public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions options) : base(options)
    { }
    
    public DbSet<Rol> Roles { get; set; }
    public DbSet<RolUsuario> RolUsuarios { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<CategoriaPersona> CategoriaPersonas { get; set; }
    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<ContactoPersona> ContactoPersonas { get; set; }
    public DbSet<Contrato> Contratos { get; set; }
    public DbSet<Contrato> ContratoEmpleados { get; set; }
    public DbSet<Contrato> ContratoClientes { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<DireccionPersona> DireccionPersonas { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Programacion> Programaciones { get; set; }
    public DbSet<TipoContacto> TipoContactos { get; set; }
    public DbSet<TipoDireccion> TipoDirecciones { get; set; }
    public DbSet<TipoPersona> TipoPersonas { get; set; }
    public DbSet<Turno> Turnos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}

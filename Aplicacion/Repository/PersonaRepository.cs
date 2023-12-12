
using System.Collections;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PersonaRepository : GenericRepo<Persona>, IPersona
{
    protected readonly ApiContext _context;

    public PersonaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas
            .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public virtual async Task<(int totalRegistros, object registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = (
             _context.Personas.AsQueryable()
            );

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    /* #1 listar todos loa empleados de la empresa de seguridad */
    public async Task<IEnumerable<Persona>> RetornarEmpleados()
    {
        return await _context.Personas
        .Where(p => p.TipoPersona.Descripcion.ToLower().Equals("empleado"))
        .ToListAsync();
    }
    /* #2 Listar todos los empleados que son vigilantes */
    public async Task<IEnumerable<Persona>> RetornarEmpleadosQueSonVigilantes()
    {
        return await _context.Personas
        .Where(p => p.CategoriaPersona.NombreCategoria.ToLower().Equals("vigilante"))
        .ToListAsync();
    }
    
    /* #3 Listar los numeros de contacto de un empleado que sea vigilante */
    public async Task<IEnumerable<object>> RetornarTelefonosDeVigilante(string documento)
    {
        return await _context.Personas
        .Where(p => p.IdentificacionPersona.ToLower().Equals(documento))
        .Where(p => p.CategoriaPersona.NombreCategoria.ToLower().Equals("vigilante"))
        .SelectMany(p => p.ContactoPersonas) 
        .Select(contacto => new {
            TipoContacto = contacto.TipoContacto,  
            Numero = contacto.Descripcion
        })
        .ToListAsync();
    }

    /* #4 Listar todos los clientes que vivan en la ciudad de bucaramanga */
    public async Task<IEnumerable<Persona>> ClientesQueVivenEnBucaramanga()
    {
        return await _context.Personas
        .Where(p => p.TipoPersona.Descripcion.ToLower().Equals("cliente"))
        .Where(p => p.Ciudad.NombreCiudad.ToLower().Equals("bucaramanga"))
        .ToListAsync();
    }
    
    /* #5 listar todos loa empleados que vivan en grion o piedecuesta */
    public async Task<IEnumerable<Persona>> RetornarEmpleadosDeGironOPiedecuesta()
    {
        return await _context.Personas
        .Where(p => p.TipoPersona.Descripcion.ToLower().Equals("empleado"))
        .Where(p => p.Ciudad.NombreCiudad.ToLower().Equals("giron") || p.Ciudad.NombreCiudad.ToLower().Equals("piedecuesta"))
        .ToListAsync();
    }
    
    /* #6 Listar todos los clientes con mas de 5 años de antiguedad */
    public async Task<IEnumerable<Persona>> ClientesConMasDe5AñosAntiguedad()
    {
        var fechaHoy = DateTime.Today.Year;
        return await _context.Personas
        .Where(p => p.TipoPersona.Descripcion.ToLower().Equals("cliente"))
        .Where(p => fechaHoy - p.FechaRegistro.Year >= 5 )
        .ToListAsync();
    }

    /* #7 Listar todos los contratos cuyo estado es activo. Se debe
    mostrar el nro de contrato, el nombre del cliente y el empleado
    que registro el contrato */
    public async Task<IEnumerable<object>> ContratosActivosConClienteYEmpleado()
    {
        return await _context.Contratos
        .Where(c => c.Estado.Descripcion.ToLower().Equals("activo"))
        .Select(cont => new {
            NumeroContrato = cont.Id,
            NombreCliente = cont.Cliente.Nombre,
            NombreEmpleado = cont.Empleado.Nombre,
            FechaInicio = cont.FechaContrato,
            FechaFin = cont.FechaFin
        })
        .ToListAsync();
    }

}
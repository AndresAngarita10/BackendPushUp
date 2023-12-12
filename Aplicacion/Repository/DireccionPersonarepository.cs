
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class DireccionPersonarepository : GenericRepo<DireccionPersona>, IDireccionPersona
{
    protected readonly ApiContext _context;

    public DireccionPersonarepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DireccionPersona>> GetAllAsync()
    {
        return await _context.DireccionPersonas
            .ToListAsync();
    }

    public override async Task<DireccionPersona> GetByIdAsync(int id)
    {
        return await _context.DireccionPersonas
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public virtual async Task<(int totalRegistros, object registros)> GetAllAsync(int pageIndez, int pageSize, string search) 
    {
        var query = (
             _context.DireccionPersonas.AsQueryable()
            );

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Direccion.Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
}
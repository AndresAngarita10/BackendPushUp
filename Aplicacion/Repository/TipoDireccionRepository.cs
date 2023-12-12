
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class TipoDireccionRepository : GenericRepo<TipoDireccion>, ITipoDireccion
{
    protected readonly ApiContext _context;

    public TipoDireccionRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoDireccion>> GetAllAsync()
    {
        return await _context.TipoDirecciones
            .ToListAsync();
    }

    public override async Task<TipoDireccion> GetByIdAsync(int id)
    {
        return await _context.TipoDirecciones
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public virtual async Task<(int totalRegistros, object registros)> GetAllAsync(int pageIndez, int pageSize, string search) 
    {
        var query = (
             _context.TipoDirecciones.AsQueryable()
            );

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Id.ToString().Contains(search));
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
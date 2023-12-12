
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class ContactoPersonaRepository : GenericRepo<ContactoPersona>, IContactoPersona
{
    protected readonly ApiContext _context;

    public ContactoPersonaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<ContactoPersona>> GetAllAsync()
    {
        return await _context.ContactoPersonas
            .ToListAsync();
    }

    public override async Task<ContactoPersona> GetByIdAsync(int id)
    {
        return await _context.ContactoPersonas
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public virtual async Task<(int totalRegistros, object registros)> GetAllAsync(int pageIndez, int pageSize, string search) 
    {
        var query = (
             _context.ContactoPersonas.AsQueryable()
            );

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Descripcion.Contains(search));
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
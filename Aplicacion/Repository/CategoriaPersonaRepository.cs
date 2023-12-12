
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class CategoriaPersonaRepository : GenericRepo<CategoriaPersona>, ICategoriaPersona
{
    protected readonly ApiContext _context;

    public CategoriaPersonaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<CategoriaPersona>> GetAllAsync()
    {
        return await _context.CategoriaPersonas
            .ToListAsync();
    }

    public override async Task<CategoriaPersona> GetByIdAsync(int id)
    {
        return await _context.CategoriaPersonas
        .FirstOrDefaultAsync(p => p.Id == id);
    }

}


using Dominio.Entities;

namespace API.Dtos;

public class PersonaDto : BaseEntity
{
    public string IdentificacionPersona { get; set; }
    public string Nombre { get; set; }
    public DateOnly FechaRegistro { get; set; }
    public int IdTPersonaFK { get; set; }
    public int IdCategoriaFK { get; set; }
    public int IdCiudad { get; set; }
}

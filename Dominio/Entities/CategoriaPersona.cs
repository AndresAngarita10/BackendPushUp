
namespace Dominio.Entities;

public class CategoriaPersona : BaseEntity
{
    public string NombreCategoria { get; set; }
    public ICollection<Persona> Personas { get; set; }
}

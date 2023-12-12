
namespace Dominio.Entities;

public class ContactoPersona : BaseEntity
{
    public string Descripcion { get; set; }
    public int IdPersonaFK { get; set; }
    public Persona Persona { get; set; }
    public int IdContactoFK { get; set; }
    public TipoContacto TipoContacto { get; set; }
}

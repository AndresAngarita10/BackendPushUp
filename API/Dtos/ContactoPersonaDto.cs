
using Dominio.Entities;

namespace API.Dtos;

public class ContactoPersonaDto : BaseEntity
{
    public string Descripcion { get; set; }
    public int IdPersonaFK { get; set; }
    public int IdContactoFK { get; set; }
}

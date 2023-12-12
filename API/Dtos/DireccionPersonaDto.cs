
using Dominio.Entities;

namespace API.Dtos;

public class DireccionPersonaDto : BaseEntity
{
    public string Direccion { get; set; }
    public int IdPersonaFK { get; set; }
    public int IdTDireccionFK { get; set; }
}


namespace Dominio.Entities;

public class DireccionPersona : BaseEntity
{
    public string Direccion { get; set; }
    public int IdPersonaFK { get; set; }
    public Persona Persona { get; set; }
    public int IdTDireccionFK { get; set; }
    public TipoDireccion TipoDireccion { get; set; }
}

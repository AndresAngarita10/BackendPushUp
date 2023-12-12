
namespace Dominio.Entities;

public class TipoDireccion : BaseEntity
{
    public string Descipcion { get; set; }
    public ICollection<DireccionPersona> DireccionPersonas { get; set; }
}

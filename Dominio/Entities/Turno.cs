
namespace Dominio.Entities;

public class Turno : BaseEntity
{
    public string NombreTurno { get; set; }
    public string HoraTurnoInicio { get; set; }
    public string HoraTurnoFin { get; set; }
    public ICollection<Programacion> Programaciones { get; set; }

}

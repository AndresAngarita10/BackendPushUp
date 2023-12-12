
namespace Dominio.Entities;

public class Programacion : BaseEntity
{
    public int IdContrato { get; set; }
    public Contrato Contrato { get; set; }
    public int IdTurno { get; set; }
    public Turno Turno { get; set; }
    public int IdEmpleado { get; set; }
    public Persona Empleado { get; set; }
}


namespace Dominio.Entities;

public class Contrato : BaseEntity
{
    public int IdCliente { get; set; }
    public Persona Cliente { get; set; }
    public DateOnly FechaContrato { get; set; }
    public int IdEmpleado { get; set; }
    public Persona Empleado { get; set; }
    public DateOnly FechaFin { get; set; }
    public int IdEstado { get; set; }
    public Estado Estado { get; set; }
    public ICollection<Programacion> Programaciones { get; set; }
}

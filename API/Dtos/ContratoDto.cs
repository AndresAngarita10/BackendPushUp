
using Dominio.Entities;

namespace API.Dtos;

public class ContratoDto : BaseEntity
{
    public int IdCliente { get; set; }
    public DateOnly FechaContrato { get; set; }
    public int IdEmpleado { get; set; }
    public DateOnly FechaFin { get; set; }
    public int IdEstado { get; set; }
}

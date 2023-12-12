
using Dominio.Entities;

namespace API.Dtos;

public class ProgramacionDto : BaseEntity
{
    public int IdContrato { get; set; }
    public int IdTurno { get; set; }
    public int IdEmpleado { get; set; }
}

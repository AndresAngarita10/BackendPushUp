
using Dominio.Entities;

namespace API.Dtos;

public class TurnoDto : BaseEntity
{
    public string NombreTurno { get; set; }
    public string HoraTurnoInicio { get; set; }
    public string HoraTurnoFin { get; set; }
}

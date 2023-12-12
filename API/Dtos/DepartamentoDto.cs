
using Dominio.Entities;

namespace API.Dtos;

public class DepartamentoDto : BaseEntity
{
    public string NombreDep { get; set; }
    public int IdPaisFK { get; set; }
}

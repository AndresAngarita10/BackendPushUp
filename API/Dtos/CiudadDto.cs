
using Dominio.Entities;

namespace API.Dtos;

public class CiudadDto : BaseEntity
{
    public string NombreCiudad { get; set; }
    public int IdDepartamentoFK { get; set; }
}

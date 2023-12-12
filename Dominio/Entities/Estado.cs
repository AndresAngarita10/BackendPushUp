
namespace Dominio.Entities;

public class Estado : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<Contrato> Contratos { get; set; }
}

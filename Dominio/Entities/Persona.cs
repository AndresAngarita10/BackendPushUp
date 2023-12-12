
namespace Dominio.Entities;

public class Persona : BaseEntity
{
    public string IdentificacionPersona { get; set; }
    public string Nombre { get; set; }
    public DateOnly FechaRegistro { get; set; }
    public int IdTPersonaFK { get; set; }
    public TipoPersona TipoPersona { get; set; }
    public int IdCategoriaFK { get; set; }
    public CategoriaPersona CategoriaPersona { get; set; }
    public int IdCiudad { get; set; }
    public Ciudad Ciudad { get; set; }
    public ICollection<DireccionPersona> DireccionPersonas { get; set; }
    public ICollection<ContactoPersona> ContactoPersonas { get; set; }
    public ICollection<Contrato> ContratoClientes { get; set; }
    public ICollection<Contrato> ContratoEmpleados { get; set; }
    public ICollection<Programacion> Programaciones { get; set; }

}

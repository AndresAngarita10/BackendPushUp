namespace Dominio.Interfaces;
public interface IUnitOfWork
{
    IRol Roles { get; }
    IUsuario Usuarios { get; }
    ICategoriaPersona CategoriaPersonas { get; }
    ICiudad Ciudades { get; }
    IContactoPersona ContactoPersonas { get; }
    IContrato Contratos { get; }
    IDepartamento Departamentos { get; }
    IDireccionPersona DireccionPersonas { get; }
    IEstado Estados { get; }
    IPais Paises { get; }
    IPersona Personas { get; }
    IProgramacion Programaciones { get; }
    ITipoContacto TipoContactos { get; }
    ITipoDireccion TipoDirecciones { get; }
    ITipoPersona TipoPersonas { get; }
    ITurno Turnos { get; }


    Task<int> SaveAsync();
}

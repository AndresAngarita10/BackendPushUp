
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IPersona : IGenericRepo<Persona>
{

    /* #1 listar todos loa empleados de la empresa de seguridad */
    public Task<IEnumerable<Persona>> RetornarEmpleados();
    /* #2 Listar todos los empleados que son vigilantes */
    public Task<IEnumerable<Persona>> RetornarEmpleadosQueSonVigilantes();
    /* #3 Listar los numeros de contacto de un empleado que sea vigilante */
    public Task<IEnumerable<object>> RetornarTelefonosDeVigilante(string documento);

    /* #4 Listar todos los clientes que vivan en la ciudad de bucaramanga */
    public Task<IEnumerable<Persona>> ClientesQueVivenEnBucaramanga();
    /* #5 listar todos loa empleados que vivan en grion o piedecuesta */
    public Task<IEnumerable<Persona>> RetornarEmpleadosDeGironOPiedecuesta();

    /* #6 Listar todos los clientes con mas de 5 años de antiguedad */
    public Task<IEnumerable<Persona>> ClientesConMasDe5AñosAntiguedad();
    
    /* #7 Listar todos los contratos cuyo estado es activo. Se debe
    mostrar el nro de contrato, el nombre del cliente y el empleado
    que registro el contrato */
    public Task<IEnumerable<object>> ContratosActivosConClienteYEmpleado();
}

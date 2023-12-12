
using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
/* [Authorize] */

public class PersonaController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public PersonaController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
    {
        var entidad = await unitofwork.Personas.GetAllAsync();
        return mapper.Map<List<PersonaDto>>(entidad);
    }
    
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<object>>> GetAllAsync([FromQuery] Params paisParams)
    {
        var entidad = await unitofwork.Personas.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var listEntidad = mapper.Map<List<object>>(entidad.registros);
        return new Pager<object>(listEntidad, entidad.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }
    
    [HttpGet("Consulta1")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> RetornarEmpleados()
    {
        var entidad = await unitofwork.Personas.RetornarEmpleados();
        return mapper.Map<List<PersonaDto>>(entidad);
    }
    
    [HttpGet("Consulta2")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> RetornarEmpleadosQueSonVigilantes()
    {
        var entidad = await unitofwork.Personas.RetornarEmpleadosQueSonVigilantes();
        return mapper.Map<List<PersonaDto>>(entidad);
    }

    [HttpGet("Consulta3{documento}")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> RetornarTelefonosDeVigilante(string documento)
    {
        var entidad = await unitofwork.Personas.RetornarTelefonosDeVigilante(documento);
        return mapper.Map<List<PersonaDto>>(entidad);
    }


    [HttpGet("Consulta4")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> ClientesQueVivenEnBucaramanga()
    {
        var entidad = await unitofwork.Personas.ClientesQueVivenEnBucaramanga();
        return mapper.Map<List<PersonaDto>>(entidad);
    }
    
    [HttpGet("Consulta5")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> RetornarEmpleadosDeGironOPiedecuesta()
    {
        var entidad = await unitofwork.Personas.RetornarEmpleadosDeGironOPiedecuesta();
        return mapper.Map<List<PersonaDto>>(entidad);
    }
    
    [HttpGet("Consulta6")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> ClientesConMasDe5AñosAntiguedad()
    {
        var entidad = await unitofwork.Personas.ClientesConMasDe5AñosAntiguedad();
        return mapper.Map<List<PersonaDto>>(entidad);
    }
    
    [HttpGet("Consulta7")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> ContratosActivosConClienteYEmpleado()
    {
        var entidad = await unitofwork.Personas.ContratosActivosConClienteYEmpleado();
        return mapper.Map<List<PersonaDto>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PersonaDto>> Get(int id)
    {
        var entidad = await unitofwork.Personas.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<PersonaDto>(entidad);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Persona>> Post(PersonaDto entidadDto)
    {
        var entidad = this.mapper.Map<Persona>(entidadDto);
        this.unitofwork.Personas.Add(entidad);
        await unitofwork.SaveAsync();
        if(entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new {id = entidadDto.Id}, entidadDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody]PersonaDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Persona>(entidadDto);
        unitofwork.Personas.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.Personas.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.Personas.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}


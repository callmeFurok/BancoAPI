using BancoAPI.Data;
using BancoAPI.Modelos;
using BancoAPI.Modelos.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    [Produces("application/json")]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClientesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Metodos Get

        // GET: api/Clientes
        [HttpGet(Name = "ObtenerClientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Cliente>>> ObtenerClientes()
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var listaClientes = await _context.Clientes.AsNoTracking().ToListAsync();
            return Ok(listaClientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id:Guid}", Name = "ObtenerClienteId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Cliente>> ObtenerClienteId(Guid id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        #endregion Metodos Get

        #region Crear Cliente

        [HttpPost(Name = "CrearCliente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CrearClienteDto>> CrearCliente([FromBody] CrearClienteDto crearClienteDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Ingrese los datos de manera correcta");
                return BadRequest(ModelState);
            }

            if (crearClienteDto == null)
            {
                return BadRequest(ModelState);
            }
            // crear nuevo cliente usando la Dto
            var nuevoCliente = new Cliente()
            {
                Id = Guid.NewGuid(),
                Contrasenia = crearClienteDto.Contrasenia,
                Direccion = crearClienteDto.Direccion,
                Edad = crearClienteDto.Edad,
                Estado = crearClienteDto.Estado,
                Genero = crearClienteDto.Genero,
                Identificacion = crearClienteDto.Identificacion,
                Nombre = crearClienteDto.Identificacion,
                Telefono = crearClienteDto.Telefono
            };

            await _context.Clientes.AddAsync(nuevoCliente);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("ObtenerClienteId", new { id = nuevoCliente.Id }, nuevoCliente);
        }

        #endregion Crear Cliente

        #region Actualizar todo los datos del cliente

        [HttpPut("{id:Guid}", Name = "ActualizarClienteCompleto")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizarClienteCompleto(Guid id, [FromBody] Cliente cliente)
        {

            var clienteActualizar = await _context.Clientes.FindAsync(id);

            if (clienteActualizar == null)
            {
                return NotFound("Cliente no encontrado");
            }

            // actualizar el objeto con los datos de cliente
            clienteActualizar.Id = id;
            clienteActualizar.Contrasenia = cliente.Contrasenia;
            clienteActualizar.Estado = cliente.Estado;
            clienteActualizar.Nombre = cliente.Nombre;
            clienteActualizar.Edad = cliente.Edad;
            clienteActualizar.Genero = cliente.Genero;
            clienteActualizar.Identificacion = cliente.Identificacion;
            clienteActualizar.Direccion = cliente.Direccion;
            clienteActualizar.Telefono = cliente.Telefono;

            _context.Clientes.Update(clienteActualizar);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("ObtenerClienteId", new { id = clienteActualizar.Id }, clienteActualizar);
        }

        #endregion Actualizar todo los datos del cliente

        #region Actualizar un dato del cliente

        [HttpPatch("{id:Guid}", Name = "ActualizarClienteParcial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActualizarClienteParcial(Guid id, JsonPatchDocument<Cliente> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var clienteActualizar = await _context.Clientes.FindAsync(id);

            if (clienteActualizar == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(clienteActualizar, ModelState);

            await _context.SaveChangesAsync();

            return Ok(clienteActualizar);
        }

        #endregion Actualizar un dato del cliente

        #region Borrar cliente

        [HttpDelete("{id:Guid}", Name = "BorrarCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BorrarCliete(Guid id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok("Cliente eliminado con exito");
        }

        #endregion Borrar cliente
    }
}
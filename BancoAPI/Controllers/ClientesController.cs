using AutoMapper;
using BancoAPI.Modelos;
using BancoAPI.Modelos.Dtos;
using BancoAPI.Repositorio.IRepositorio;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BancoAPI.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    [Produces("application/json")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepositorio _context;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepositorio context, IMapper mapper)
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

            var listaClientes = await _context.ObtenerTodosAsync();

            return Ok(listaClientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id:Guid}", Name = "ObtenerClienteId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Cliente>> ObtenerClienteId(Guid id)
        {

            var cliente = await _context.ObtenerEspecificoAsync(c => c.Id == id);

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
            if (_context.ExisteCliente(crearClienteDto.Nombre))
            {
                ModelState.AddModelError("", "El cliente ya existe");
                return StatusCode(404, ModelState);
            }

            Cliente nuevoCliente = _mapper.Map<Cliente>(crearClienteDto);

            await _context.CrearAsync(nuevoCliente);


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



            // actualizar el objeto con los datos de cliente
            Cliente clienteActualizar = _mapper.Map<Cliente>(cliente);
            clienteActualizar.Id = id;


            await _context.ActualizarAsync(clienteActualizar);


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

            var clienteActualizar = await _context.ObtenerEspecificoAsync(c => c.Id == id);

            if (clienteActualizar == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(clienteActualizar, ModelState);

            await _context.ActualizarAsync(clienteActualizar);

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

            var cliente = await _context.ObtenerEspecificoAsync(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound("Usuario a eliminar no encontrado");
            }

            await _context.EliminarAsync(cliente);

            return Ok("Cliente eliminado con exito");
        }

        #endregion Borrar cliente
    }
}
using BancoAPI.Data;
using BancoAPI.Modelos;
using BancoAPI.Modelos.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CuentasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CuentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cuentas
        [HttpGet(Name = "ObtenerCuentas")]
        public async Task<ActionResult<IEnumerable<Cuenta>>> GetCuentas()
        {
            if (_context.Cuentas == null)
            {
                return NotFound();
            }
            return await _context.Cuentas.ToListAsync();
        }

        // GET: api/Cuentas/5
        [HttpGet("{id}", Name = "ObtenerCuentaId")]
        public async Task<ActionResult<Cuenta>> GetCuenta(Guid id)
        {
            if (_context.Cuentas == null)
            {
                return NotFound();
            }
            var cuenta = await _context.Cuentas.FindAsync(id);

            if (cuenta == null)
            {
                return NotFound();
            }

            return Ok(cuenta);
        }

        // PUT: api/Cuentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuenta(Guid id, Cuenta cuenta)
        {
            if (id != cuenta.Id)
            {
                return BadRequest();
            }

            _context.Entry(cuenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cuentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{clienteId:Guid}")]
        public async Task<ActionResult<Cuenta>> PostCuenta(Guid clienteId, [FromBody] CrearCuentaDto cuentaDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Ingrese los datos de manera correcta");
                return BadRequest(ModelState);
            }

            if (cuentaDto == null)
            {
                return BadRequest(ModelState);
            }

            // crear nueva cuenta con cliente id
            var nuevaCuenta = new Cuenta()
            {
                Id = Guid.NewGuid(),
                ClienteId = clienteId,
                NumeroCuenta = cuentaDto.NumeroCuenta,
                Estado = cuentaDto.Estado,
                TipoCuenta = cuentaDto.TipoCuenta,
                SaldoInicial = cuentaDto.SaldoInicial
            };
            _context.Cuentas.Add(nuevaCuenta);
            await _context.SaveChangesAsync();


            return CreatedAtAction("ObtenerCuentaId", new { id = nuevaCuenta.Id }, nuevaCuenta);
        }

        // DELETE: api/Cuentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuenta(Guid id)
        {
            if (_context.Cuentas == null)
            {
                return NotFound();
            }
            var cuenta = await _context.Cuentas.FindAsync(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            _context.Cuentas.Remove(cuenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuentaExists(Guid id)
        {
            return (_context.Cuentas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

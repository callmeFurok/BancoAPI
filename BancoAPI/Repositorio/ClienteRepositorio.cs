using BancoAPI.Data;
using BancoAPI.Modelos;
using BancoAPI.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BancoAPI.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CrearAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await GuardarAsync();
        }

        public async Task EliminarAsync(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await GuardarAsync();
        }

        public async Task GuardarAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> ObtenerEspecificoAsync(Expression<Func<Cliente, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Cliente> query = _context.Clientes;
            if (!tracked)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Cliente>> ObtenerTodosAsync(Expression<Func<Cliente, bool>> filter = null)
        {
            IQueryable<Cliente> query = _context.Clientes;

            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }


        public bool ExisteCliente(string nombre)
        {
            bool valor = _context.Clientes.Any(c => c.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            return valor;
        }

        public async Task ActualizarAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await GuardarAsync();
        }
    }
}

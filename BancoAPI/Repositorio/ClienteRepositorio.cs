using BancoAPI.Data;
using BancoAPI.Modelos;
using BancoAPI.Repositorio.IRepositorio;

namespace BancoAPI.Repositorio
{
    public class ClienteRepositorio : RepositorioGenerico<Cliente>, IClienteRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool ExisteCliente(string nombre)
        {
            bool valor = _context.Clientes.Any(c => c.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            return valor;
        }

        public async Task ActualizarAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
using BancoAPI.Modelos;
using System.Linq.Expressions;

namespace BancoAPI.Repositorio.IRepositorio
{
    public interface IClienteRepositorio
    {
        Task<List<Cliente>> ObtenerTodosAsync(Expression<Func<Cliente, bool>> filter = null);
        Task<Cliente> ObtenerEspecificoAsync(Expression<Func<Cliente, bool>> filter = null, bool tracked = true);

        Task CrearAsync(Cliente cliente);
        Task ActualizarAsync(Cliente cliente);
        Task EliminarAsync(Cliente cliente);
        Task GuardarAsync();
        bool ExisteCliente(string nombre);
    }
}

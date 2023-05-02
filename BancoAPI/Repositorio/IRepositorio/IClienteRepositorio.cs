using BancoAPI.Modelos;

namespace BancoAPI.Repositorio.IRepositorio
{
    public interface IClienteRepositorio : IRepositorioGenerico<Cliente>
    {

        Task ActualizarAsync(Cliente cliente);
        bool ExisteCliente(string nombre);
    }

}

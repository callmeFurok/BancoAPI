using System.Linq.Expressions;

namespace BancoAPI.Repositorio.IRepositorio
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task<List<T>> ObtenerTodosAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> ObtenerEspecificoAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
        Task CrearAsync(T cliente);
        Task EliminarAsync(T cliente);
        Task GuardarAsync();
    }
}

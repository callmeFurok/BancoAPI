namespace BancoAPI.Repositorio
{
    // Repositorio generico para usar el patron Repository 
    public interface IRepositorio<TEntity>
    {
        // metodo para obtener todos los registros
        ICollection<TEntity> ObtenerTodos();

        // metodo para obtener un registro por Guid
        TEntity ObtenerPorId(Guid id);

        // metodo para crear un registro
        bool Crear(TEntity entity);

        // metodo para actualizar un registro 
        bool Actualizar(TEntity entity);

        // metodo para borrar un registro
        bool Borrar(TEntity entity);

        // metodo para guardar los cambios usando Unit of Work
        bool Guardar();
    }
}

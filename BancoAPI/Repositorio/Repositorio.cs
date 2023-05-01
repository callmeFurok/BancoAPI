using BancoAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Repositorio
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        // se usa DbSet para saber con que modelo se esta trabajando
        private readonly DbSet<TEntity> _dbSet;
        public Repositorio(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            // creamos el objeto por medio del tipo que vamos a recibir
            _dbSet = applicationDbContext.Set<TEntity>();
        }

        public bool Actualizar(TEntity entity)
        {
            _dbSet.Attach(entity);
            _applicationDbContext.Entry(entity).State = EntityState.Modified;

            return Guardar();
        }

        public bool Borrar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Crear(TEntity entity)
        {
            _dbSet.Add(entity);
            return Guardar();

        }

        public bool Guardar() => _applicationDbContext.SaveChanges() >= 0 ? true : false;

        public TEntity ObtenerPorId(Guid id) => _dbSet.Find(id);



        public ICollection<TEntity> ObtenerTodos() => _dbSet.ToList();
    }
}

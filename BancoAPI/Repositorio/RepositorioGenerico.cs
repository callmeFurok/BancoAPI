using BancoAPI.Data;
using BancoAPI.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BancoAPI.Repositorio
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        internal DbSet<T> _dbSet;

        public RepositorioGenerico(ApplicationDbContext context)
        {
            _context = context;
            this._dbSet = _context.Set<T>();
        }

        public async Task CrearAsync(T entidad)
        {
            await _dbSet.AddAsync(entidad);
            await GuardarAsync();
        }

        public async Task EliminarAsync(T entidad)
        {
            _dbSet.Remove(entidad);
            await GuardarAsync();
        }

        public async Task GuardarAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> ObtenerEspecificoAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> ObtenerTodosAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }
    }
}
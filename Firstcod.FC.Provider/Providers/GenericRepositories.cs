using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Firstcod.FC.Provider.Providers
{
    public class GenericRepositories<T> : IDisposable, IGenericRepositories<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _entity;

        public GenericRepositories(DbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _entity.Where(predicate).ToList();
        }

        public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entity.Where(predicate).ToListAsync();
        }

        public T FindById(Expression<Func<T, bool>> predicate)
        {
            return _entity.SingleOrDefault(predicate);
        }

        public async Task<T> FindByIdAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entity.SingleOrDefaultAsync(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public void Add(T entity)
        {
            _entity.Add(entity);
        }

        public void Delete(T entity)
        {
            _entity.Remove(entity);
        }

        public void Update(T entity)
        {
            _entity.Update(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}

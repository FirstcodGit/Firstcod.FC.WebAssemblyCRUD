using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Firstcod.FC.Provider.Providers
{
    public interface IGenericRepositories<T> where T: class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);

        T FindById(Expression<Func<T, bool>> predicate);
        Task<T> FindByIdAsync(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }
}

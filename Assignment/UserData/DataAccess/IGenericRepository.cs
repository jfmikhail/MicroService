using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData.DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsyn();
        IEnumerable<T> ListAll();
        T Get(int id);
        Task<T> GetAsync(int id);
        T Insert(T t);
        Task<T> InsertAsyn(T t);
        void Delete(T entity);
        Task<int> DeleteAsyn(T entity);
        T Update(T t, object key);
        Task<T> UpdateAsyn(T t, object key);
    }
}

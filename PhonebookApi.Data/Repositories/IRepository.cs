using System;
using System.Linq;
using System.Linq.Expressions;
 
namespace PhonebookApi.Data.Repositories
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
using System.Linq.Expressions;

namespace Exam.Application.IRepository
{
  
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        //   IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        bool DeleteAsynctrue(T entity);

        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        Task<int> DeleteAsync(T entity);
        void Save();
        void AddRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
        void DeleteOption(T obj);

        Task<int> SaveAsync();


    }
}

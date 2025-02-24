
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{

    // IRepositoryBase is a generic interface that provides CRUD operations for a given entity type T.
    // trackChanges is used to determine whether the repository should track changes to the entity.
    public interface IRepositoryBase<T>
    {
        // CRUD operations
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}

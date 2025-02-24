using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    // RepositoryBase is a generic abstract class that implements IRepositoryBase<T>.
    // base classi abstract yaptik ki instance alinamasin. yani new'lenemesin. diger repolar bu classi inherit edecek. new'lenmeyecek.
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly RepositoryContext _context;

        //constructor injection yaptik dbcontexti.
        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        // Lambda fonksiyon kullanarak context araciligi ile entity'i ekliyoruz.
        // buradaki set kismi context'in DbSet'ini temsil eder.
        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        // trackChanges false ise AsNoTracking() metodu ile entity'nin degisikliklerini takip etmiyoruz.
        // AsNoTracking metodu entity'nin degisikliklerini takip etmez. Bu sayede performans artar.
        // Degisiklik izledigimizde saveChanges() metodu cagirildiginda degisiklikleri kaydeder.
        public IQueryable<T> FindAll(bool trackChanges) => 
            !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => 
            !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);


        public void Update(T entity) => _context.Set<T>().Update(entity);

    }
}

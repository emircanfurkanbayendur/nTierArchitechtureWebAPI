using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    // Burada BookRepository sınıfı, Book sınıfı için CRUD işlemlerini gerçekleştiren RepositoryBase<Book> sınıfından türetilmiştir.
    internal class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {

            
        }

        //burada kulandigimiz create metodu RepositoryBase sınıfından gelmektedir.
        public void CreateOneBook(Book book) => Create(book);

        // burada kullandigimiz delete metodu RepositoryBase sınıfından gelmektedir.
        public void DeleteOneBook(Book book) => Delete(book);

        // burada kullandigimiz FindAll metodu RepositoryBase sınıfından gelmektedir.
        // istersek methodlarin sonuna LINQ sorgulari ekleyebiliriz.
        public IQueryable<Book> GetAllBooks(bool trackChanges) => FindAll(trackChanges).OrderBy(b => b.ID);

        // burada kullandigimiz FindByCondition metodu RepositoryBase sınıfından gelmektedir.
        public IQueryable<Book> GetOneBook(int id, bool trackChanges) => FindByCondition(b => b.ID == id, trackChanges);


        // burada kullandigimiz update metodu RepositoryBase sınıfından gelmektedir.
        public void UpdateOneBook(Book book) => Update(book);

    }
}

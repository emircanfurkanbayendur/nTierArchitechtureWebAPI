using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        // `IQueryable<Book>`: Sorguyu veritabanında geç çalıştırarak optimize eder,
        // sadece gerekli verileri çeker ve SQL sorgusunu veritabanında oluşturur.
        IQueryable<Book> GetAllBooks(bool trackChanges);

        Book GetOneBookByID(int id, bool trackChanges);
        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);

    }
}

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

        // `IQueryable<Book>`: Veritabanında sorguyu geç çalıştırarak optimize eder,
        // yalnızca gerekli veriyi çeker ve filtreleme/sıralama veritabanında yapılır.
        IQueryable<Book> GetOneBook(int id, bool trackChanges);
        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);

    }
}

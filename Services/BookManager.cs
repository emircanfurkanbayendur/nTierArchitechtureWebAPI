using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    // Katmanlar arası ilişki:
    // Controller -> ServiceManager ile iletişim kurar.
    // ServiceManager -> Tüm servisleri yönetir, burada BookService ile çalışır.
    // BookService -> RepositoryManager ile iletişim kurar ve veriye erişir.
    // RepositoryManager -> Tüm repositoryleri yönetir, burada BookRepository ile çalışır.
    // BookRepository -> Veritabanı işlemlerini gerçekleştirir.
    // BookRepository -> RepositoryManager Save islemini gerceklestirir.

    // Burada BookManager Repository manager araciligi ile BookRepository'e erisecegi icin, RepositoryManager'i constructor'da inject ediyoruz.
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BookManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public Book CreateOneBook(Book book)
        {
            _repositoryManager.Book.CreateOneBook(book);
            _repositoryManager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            //check entity
            var entity = _repositoryManager.Book.GetOneBookByID(id, trackChanges);
            if(entity == null)
            {
                throw new Exception($"Book with ID: {id} could not be found.");
            }

            _repositoryManager.Book.DeleteOneBook(entity);
            _repositoryManager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _repositoryManager.Book.GetAllBooks(trackChanges);
        }

        public Book GetOneBookByID(int id, bool trackChanges)
        {
            return _repositoryManager.Book.GetOneBookByID(id, trackChanges);
        }

        public void UpdateOneBook(int id, Book book, bool trackChanges)
        {
            //check entity
            var entity = _repositoryManager.Book.GetOneBookByID(id, trackChanges);
            if (entity == null)
            {
                throw new Exception($"Book with ID: {id} could not be found.");
            }

            //check params
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book));

            }

            //burada automapper kullanabiliriz.
            entity.Title = book.Title;
            entity.Price = book.Price;

            _repositoryManager.Book.UpdateOneBook(entity);
            _repositoryManager.Save();



        }
    }
}

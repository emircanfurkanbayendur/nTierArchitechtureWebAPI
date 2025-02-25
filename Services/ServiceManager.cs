using Repositories.Contracts;
using Repositories.EFCore;
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
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager));
            
        }

        //bookservice sadece cagrilirsa new'lenecek. lazy  loading.
        public IBookService BookService => _bookService.Value;
    }
}

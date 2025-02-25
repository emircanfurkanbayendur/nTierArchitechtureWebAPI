using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    // Katmanlar arası ilişki:
    // Controller -> ServiceManager ile iletişim kurar.
    // ServiceManager -> Tüm servisleri yönetir, burada BookService ile çalışır.
    // BookService -> RepositoryManager ile iletişim kurar ve veriye erişir.
    // RepositoryManager -> Tüm repositoryleri yönetir, burada BookRepository ile çalışır.
    // BookRepository -> Veritabanı işlemlerini gerçekleştirir.
    // BookRepository -> RepositoryManager Save islemini gerceklestirir.
    public interface IServiceManager
    {
        IBookService BookService { get; }
    }
}

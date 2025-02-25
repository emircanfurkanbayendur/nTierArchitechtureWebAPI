using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    // Bu manager classinda unit of work patterni uygulanmistir. bu pattern, bir veya birden fazla repository sınıfını bir arada kullanmamızı sağlar.
    // Bu sayede bir repository sınıfı üzerinde işlem yaparken, diğer repository sınıflarını da kullanabiliriz.
    // RepositoryManager butun repository sınıflarını tek bir yerde toplar.
    public interface IRepositoryManager
    {

        IBookRepository Book { get; }

        // save metodu, butun repository sınıflarındaki degisiklikleri veritabanına kaydeder.
        // repolarda db context ile degisiklik yaptiktan sonra manager uzerindeki save metodu cagirilarak degisiklikler kaydedilir.
        // repositoryler sadece degisiklik yapar, degisiklikleri kaydetme islemi manager uzerinde yapilir.
        void Save();
    }
}

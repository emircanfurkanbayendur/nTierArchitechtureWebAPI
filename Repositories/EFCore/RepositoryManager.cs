using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    // Bu manager classinda unit of work patterni uygulanmistir. bu pattern, bir veya birden fazla repository sınıfını bir arada kullanmamızı sağlar.
    // Bu sayede bir repository sınıfı üzerinde işlem yaparken, diğer repository sınıflarını da kullanabiliriz.
    // RepositoryManager butun repository sınıflarını tek bir yerde toplar.
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;

        // LAZY loading yapiyoruz. sadece cagrildiginda new'lenecek.
        private readonly Lazy<IBookRepository> _bookRepository;

        // save islemini context uzerinden yapacagimiz icin contexti burada inject ediyoruz.
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;

            // burada new'lemek yerine repository sınıflarını inject edebiliriz.
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));

        }


        
        public IBookRepository Book => _bookRepository.Value;



        // save metodu, butun repository sınıflarındaki degisiklikleri veritabanına kaydeder.
        // repolarda db context ile degisiklik yaptiktan sonra manager uzerindeki save metodu cagirilarak degisiklikler kaydedilir.
        // repositoryler sadece degisiklik yapar, degisiklikleri kaydetme islemi manager uzerinde yapilir.
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

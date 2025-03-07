﻿using Entities.Models;
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
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks(bool trackChanges);
        Book GetOneBookByID(int id, bool trackChanges);
        Book CreateOneBook(Book book);
        void UpdateOneBook(int id, Book book, bool trackChanges);
        void DeleteOneBook(int id, bool trackChanges);
    }
}

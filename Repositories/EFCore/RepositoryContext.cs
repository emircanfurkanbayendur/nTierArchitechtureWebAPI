using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    // RepositoryContext is a class that inherits from DbContext and is used to establish a connection to the database.
    // DbContext'i inherit ediyoruz. bu sinif EF Core'a aittir.
    public class RepositoryContext : DbContext
    {
        // Constructor takes DbContextOptions as a parameter.
        // This constructor is used to pass the options to the base class.
        // options'u kullanarak appsettings dosyasindan connection string'i aliyoruz.
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        // DbSet<Book> is a property that represents a collection of books in the database.
        // DbSet is a generic class that represents a collection of entities in the database.
        public DbSet<Book> Books { get; set; }


        // OnModelCreating is a method that is called when the model is being created.
        // We override this method to apply the configuration for the Book entity.
        // Bu methodu ezerek kendi yazdigimiz BookConfig class'ini uyguluyoruz.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // migration ile update-database yapildiginda config dosyasinda yazdigimiz degisiklikler dbye yansiyacak.
            modelBuilder.ApplyConfiguration(new BookConfig());

        }
    }
}

using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    // BookConfig is a class that implements IEntityTypeConfiguration<Book>.
    // This class is used to configure the Book entity in the database.
    public class BookConfig : IEntityTypeConfiguration<Book>
    {


        // Configure is a method that takes EntityTypeBuilder<Book> as a parameter.
        public void Configure (EntityTypeBuilder<Book> builder)
        {
            // HasData is a method that is used to seed the database with initial data.
            // We use this method to seed the database with three books.
            builder.HasData(
                new Book { ID = 1, Title = "Book 1", Price = 100 },
                new Book { ID = 2, Title = "Book 2", Price = 200 },
                new Book { ID = 3, Title = "Book 3", Price = 300 }
                );

        }
    }
}

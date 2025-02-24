using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    // Book is a simple entity class that represents a book with an ID, Title, and Price.
    // This class will be used to demonstrate CRUD operations in the repository pattern.
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

    }
}

using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    //controller -> serviceManager -> BookService -> RepositoryManager -> BookRepository

    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public BooksController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        //  artik burada service manager araciligi ile bookservice'e erisiyoruz. bookservice ise repository manager araciligi ile bookrepository'e erisiyor.
        // bu katmanda logic yok.
        // IActionResult -> response dondugumuzde response'un tipini belirtir.
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _serviceManager.BookService.GetAllBooks(trackChanges: false);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        // id:int -> id'nin integer olmasi gerektigini belirtir.
        // [FromRoute(Name = "id")] -> id'nin route'dan alinacagini belirtir.
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int bookID)
        {
            try
            {
                var book = _serviceManager.BookService.GetOneBookByID(bookID, false);
                if (book == null)
                {
                    return NotFound(); // 404
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // 500 Internal Server Error
            }
        }

        // [FromBody] -> request body'den veri aldigimizi belirtir.
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Entities.Models.Book book)
        {
            try
            {
                _serviceManager.BookService.CreateOneBook(book);
                return StatusCode(201, book); // 201 Created 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 400 Bad Request
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,
    [FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest(); // 400 

                _serviceManager.BookService.UpdateOneBook(id, book, true);
                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                _serviceManager.BookService.DeleteOneBook(id, false);
                return NoContent(); // 204 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            try
            {
                // check entity
                var entity = _serviceManager
                    .BookService
                    .GetOneBookByID(id, true);
                    

                if (entity is null)
                    return NotFound(); // 404

                bookPatch.ApplyTo(entity);
                _serviceManager.BookService.UpdateOneBook(id, entity, true);

                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





    }
}

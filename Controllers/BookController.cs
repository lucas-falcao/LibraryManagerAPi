using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IRepository bookDB;

        public BookController(IRepository book)
        {
            this.bookDB = book;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return Ok(bookDB.GetAll());
            
        }
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            return Ok(bookDB.GetBook(id));
        }
        [HttpPost]
        public IActionResult Post(Book book)
        {
            bookDB.AddBook(book);
            return Ok(book);
        }
        public IActionResult Put(Book book)
        {
            bookDB.UpdateBook(book);
            return Ok(book);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bookDB.DeleteBook(id);
            return Ok("Done");
        }
    }
}
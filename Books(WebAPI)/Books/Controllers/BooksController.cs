using Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        IBooksRepository<Book> _repo;

        public BooksController(IBooksRepository<Book> repo)
        {
            _repo = repo;
            _repo = new BookRepo(new BooksContext());
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _repo.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
           return _repo.GetById(id);
        }

        // POST api/<BooksController>
        [HttpPost, Authorize]
        public Book Post([FromBody] Book book)
        {
            Book temp_book = _repo.GetById(book.BookId);
          
                if (temp_book == null)
                {
                    _repo.Create(book);
                    return book;
                }
                else
                    return null;
         
            //try
            //{
            //    var file = Request.Form.Files[0];
            //    var folderName = Path.Combine("Resources", "BookImages");
            //    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            //    if (file.Length > 0)
            //    {
            //        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            //        var fullPath = Path.Combine(pathToSave, fileName);
            //        var dbPath = Path.Combine(folderName, fileName);
            //        using (var stream = new FileStream(fullPath, FileMode.Create))
            //        {
            //            file.CopyTo(stream);
            //        }
            //        return Ok(new { dbPath });
            //    }
            //    else
            //    {
            //        return BadRequest();
            //    }
            //}
            //catch (Exception ex)
            //{

            //    return StatusCode(500, $"Internal server error: {ex}");
            //}
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

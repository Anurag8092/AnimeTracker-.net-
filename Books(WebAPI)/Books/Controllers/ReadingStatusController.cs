using Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingStatusController : ControllerBase
    {

        IBooksRepository<ReadingStatus> _repo;

        public ReadingStatusController(IBooksRepository<ReadingStatus> repo)
        {
            _repo = repo;
            _repo = new ReadingStatusRepo(new BooksContext());
        }

        // GET: api/<ReadingStatusController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReadingStatusController>/5

        //Get rading status via userID
        [HttpGet("{id}"), Authorize]
        public Object GetReadingStatus(int id)
        {
            ReadingStatusRepo status = new ReadingStatusRepo();
            return status.getReadingStatus(id);
        }

        //Get rading status via bookID
        [HttpGet("book/{id}")]
        public decimal GetReadingStatusByBookId(int id)
        {
            ReadingStatusRepo status = new ReadingStatusRepo();
            return status.GetByBookId(id);
        }

        // POST api/<ReadingStatusController>
        [HttpPut, Authorize]
        public string Put([FromBody] ReadingStatus data)
        {
            ReadingStatusRepo rs = new ReadingStatusRepo();
            return rs.UpdateReadingStatus(data);

        }

        [HttpPost, Authorize]
        public string Post([FromBody] ReadingStatus data)
        {
            ReadingStatusRepo rs = new ReadingStatusRepo();
            return rs.AddBookToList(data);

        }


        // PUT api/<ReadingStatusController>/bookrating/5
        [HttpPut("bookrating/{id}")]
        public Book Put(int id)
        {
            ReadingStatusRepo rs = new ReadingStatusRepo();
            return rs.UpdateBookRating(id);
        }

        // DELETE api/<ReadingStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

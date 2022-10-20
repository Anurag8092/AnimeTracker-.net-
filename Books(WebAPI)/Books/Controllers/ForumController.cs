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
    public class ForumController : ControllerBase
    {
        IBooksRepository<Queries> _repo;

        public ForumController(IBooksRepository<Queries> repo)
        {
            _repo = repo;
            _repo = new QueriesRepo(new BooksContext());
        }

        // GET: api/<Forum>
        [HttpGet]
        public IEnumerable<Queries> Get()
        {
            return _repo.GetAll() ;
        }

        // GET api/<Forum>/5
        [HttpGet("{id}")]
        public Object Get(int id)
        {
            QueriesRepo temp = new QueriesRepo();
            return temp.GetByQueryId(id);
        }

        // GET api/<Forum>/answer/5
        [HttpGet("answer/{id}")]
        public Object GetAns(int id)
        {
            AnswersRepo temp_ans = new AnswersRepo();
            return temp_ans.GetAnsByQueryId(id);
        }

        // GET api/<Forum>/comment/5
        [HttpGet("comment/{id}")]
        public Object GetComm(int id)
        {
            CommentsRepo temp_comm = new CommentsRepo();
            return temp_comm.GetCommByAnsId(id);
        }

        // POST api/<Forum>
        [HttpPost, Authorize]
        public int Post([FromBody] Queries query)
        {
            return _repo.Create(query);
        }

        // POST api/<Forum>/answer
        [HttpPost("answer"), Authorize]
        public int PostAns([FromBody] Answers ans)
        {
            AnswersRepo temp_ans = new AnswersRepo(); 
            return temp_ans.Create(ans);
        }


        // POST api/<Forum>/comment
        [HttpPost("comment"), Authorize]
        public int PostComm([FromBody] Comments comm)
        {
            CommentsRepo temp_comm = new CommentsRepo();
            return temp_comm.Create(comm);
        }

        // PUT api/<Forum>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Forum>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

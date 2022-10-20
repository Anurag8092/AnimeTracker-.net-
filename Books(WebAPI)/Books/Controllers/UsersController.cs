using Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IBooksRepository<Users> _repo;

        public UsersController(IBooksRepository<Users> repo)
        {
            _repo = repo;
            _repo = new UserRepo(new BooksContext());
        }

        // GET: api/<UsersController>
        [HttpGet]
        [Authorize]
        public List<Users> Get()
        {
            return _repo.GetAll();        
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return _repo.GetById(id);
        }

        // GET api/<UsersController>/{email}
        [HttpGet("email={email}")]
        public Users Get(string email)
        {
            return _repo.GetByEmail(email);
        }

        //Register User
        // POST api/<UsersController>
        [HttpPost]
        public Users Post([FromBody] Users user)
        {
            Users temp_user = _repo.GetByEmail(user.Email);
            if (temp_user == null)
            {
                _repo.Create(user);
                return user;
            }
            else
                return null;
        }

        // PUT api/<UsersController>/loginuser
        [HttpPost("loginuser")]
        public IActionResult postlogin(Users loginuser)
        {
            UserRepo user = new UserRepo();
            var temp = user.GetByEmail(loginuser.Email);
            if (temp != null)
            {
                if (loginuser.Email == temp.Email && loginuser.Password == temp.Password)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("anuragisbad12345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    
                    var tokenOptions = new JwtSecurityToken(
                        issuer: "https://localhost:7630",
                        audience: "https://localhost:7630",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(50000),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { token = tokenString, user = temp});
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return BadRequest("Invalid Client Request");
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

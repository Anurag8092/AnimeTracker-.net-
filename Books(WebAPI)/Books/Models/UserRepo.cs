using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Models
{
    public class UserRepo : IBooksRepository<Users>
    {
        private BooksContext _dbctx;

        public UserRepo()
        {
            _dbctx = new BooksContext();
        }

        public UserRepo(BooksContext ctx)
        {
            _dbctx = ctx;
        }

        //Registering The User
        public int Create(Users createData)
        {

            int i = 0;
            try
            {
                if (createData != null)
                {
                    _dbctx.Users.Add(createData);
                    _dbctx.SaveChanges();
                    i = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return i;
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        //All users data
        public List<Users> GetAll()
        {
            try
            {
                return _dbctx.Users.ToList<Users>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //get user by id
        public Users GetById(int id)
        {
            try
            {
                var user = _dbctx.Users.Where(x => x.UserId == id).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get user by email
        public Users GetByEmail(string email)
        {
            try
            {
                var user = _dbctx.Users.Where(x => x.Email == email).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

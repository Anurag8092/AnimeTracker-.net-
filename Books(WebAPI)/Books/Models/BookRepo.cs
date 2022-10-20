using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Models
{
    public class BookRepo : IBooksRepository<Book>
    {

        private BooksContext _dbctx;

        public BookRepo()
        {
            _dbctx = new BooksContext();
        }

        public BookRepo(BooksContext ctx)
        {
            _dbctx = ctx;
        }
        public int Create(Book createData)
        {
            int i = 0;
            try
            {

                if (createData != null)
                {
                    _dbctx.Books.Add(createData);
                    _dbctx.SaveChanges();
                    i = 1;
                }
                else return i;
              
                 
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

        public List<Book> GetAll()
        {
            try
            {
                return _dbctx.Books.ToList<Book>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Book GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Book GetById(int id)
        {
            try
            {
                var book = _dbctx.Books.Where(x => x.BookId == id).FirstOrDefault();
                return book;
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

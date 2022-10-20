using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Models
{
    public class ReadingStatusRepo : IBooksRepository<ReadingStatus>
    {
        private BooksContext _dbctx;

        public ReadingStatusRepo()
        {
            _dbctx = new BooksContext();
        }

        public ReadingStatusRepo(BooksContext ctx)
        {
            _dbctx = ctx;
        }
        public int Create(ReadingStatus createData)
        {
            return 0;
        }

        
        public string UpdateReadingStatus(ReadingStatus createData)
        {
            var BookPresent = _dbctx.Books.Where(x => x.BookId == createData.BookId).FirstOrDefault();
            var user = _dbctx.ReadingStatus.Where(x => x.UserId == createData.UserId && x.BookId == createData.BookId).FirstOrDefault();
            try
            {
                if (BookPresent != null)
                { 
                    if(createData.Status.Length == 0)
                    user.Rating = createData.Rating;
                    else if(createData.Rating == null)
                    user.Status = createData.Status;
                    _dbctx.SaveChanges();
                    return "Status Updated";
                }
                else return "Anime Not Found";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddBookToList(ReadingStatus createData)
        {
            var BookPresent = _dbctx.Books.Where(x => x.BookId == createData.BookId).FirstOrDefault();
            var user = _dbctx.ReadingStatus.Where(x => x.UserId == createData.UserId && x.BookId == createData.BookId).FirstOrDefault();
            try
            {
                if (BookPresent != null)
                {
                    if (user == null)
                    {
                        _dbctx.ReadingStatus.Add(createData);
                        _dbctx.SaveChanges();
                        return "Anime Added to Your List";
                    }
                    else
                    {
                        return "This Anime is Already Present in Your List";
                    };
                }
                else return "Anime Not Found";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Object getReadingStatus(int id)
        {
            try
            {
                var res = (from rs in _dbctx.ReadingStatus
                           join b in _dbctx.Books on rs.BookId equals b.BookId
                           where rs.UserId == id
                           select new
                           {
                               BookId = rs.BookId,
                               UserId = rs.UserId,
                               BookName = b.BookName,
                               BookImage = b.BookImage,
                               authorName = b.AuthorName,
                               description = b.Description,
                               readingStatus = rs.Status,
                               rating = rs.Rating
                           }).ToList();

                if (res != null) return res;
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<ReadingStatus> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ReadingStatus GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        //Get reading status via book id
        public decimal GetByBookId(int id)
        {
            var res = _dbctx.ReadingStatus.Where(x => x.BookId == id).ToList();
            decimal? sum = 0;
            foreach (var item in res)
            {
                sum += item.Rating;
            }
            if (sum != 0)
            {
                decimal? avg = (sum / res.Count);
                decimal roundedAvg = Math.Round((decimal)avg, 1);
                return roundedAvg;
            }
            else return 0;
            
            
        }

        public Book UpdateBookRating(int id)
        {
            var book = _dbctx.Books.Where(x => x.BookId == id).FirstOrDefault();

            try
            {
                if (book != null)
                {
                    if (book.Rating == null || book.Rating != null)
                    {
                        //var rating = (decimal)book.Rating;
                        book.Rating = GetByBookId(id);
                        _dbctx.SaveChanges();
                        return book;
                    }
                    else return null;
                }
                else return null;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        ReadingStatus IBooksRepository<ReadingStatus>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}

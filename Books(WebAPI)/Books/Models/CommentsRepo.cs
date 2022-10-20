using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Models
{
    public class CommentsRepo : IBooksRepository<Comments>
    {

        private BooksContext _dbctx;

        public CommentsRepo()
        {
            _dbctx = new BooksContext();
        }

        public CommentsRepo(BooksContext ctx)
        {
            _dbctx = ctx;
        }
        public int Create(Comments createData)
        {

            try
            {
                if (createData != null)
                {
                    _dbctx.Comments.Add(createData);
                    _dbctx.SaveChanges();
                    return 1;
                }
                else return 0;
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

        public List<Comments> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Comments GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Comments GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Object GetCommByAnsId(int id)
        {
            try
            {
                var res = (from c in _dbctx.Comments
                           join a in _dbctx.Answers on c.AnswerId equals a.AnswerId
                           join u in _dbctx.Users on c.UserId equals u.UserId
                           where a.QueryId == id

                           select new
                           {
                               commId = c.CommentId,
                               userId = u.UserId,
                               ansId = c.AnswerId,
                               comm = c.Comment,
                               ans = a.Answer,
                               username = u.Fullname,
                               profileImage = u.ProfileImage,
                               date = c.Date
                           }).ToList();
                if (res != null) return res;
                else return null;
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

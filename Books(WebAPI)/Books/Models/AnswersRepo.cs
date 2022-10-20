using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Models
{
    public class AnswersRepo : IBooksRepository<Answers>
    {
        private BooksContext _dbctx;

        public AnswersRepo()
        {
            _dbctx = new BooksContext();
        }

        public AnswersRepo(BooksContext ctx)
        {
            _dbctx = ctx;
        }
        public int Create(Answers createData)
        {
            try
            {
                if (createData != null)
                {
                    _dbctx.Answers.Add(createData);
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

        public List<Answers> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Answers GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Object GetAnsByQueryId(int id)
        {
            try
            {

                var res = (from a in _dbctx.Answers
                           join u in _dbctx.Users on a.UserId equals u.UserId
                           where a.QueryId == id

                           select new
                           {
                               ansId = a.AnswerId,
                               queryId = a.QueryId,
                               userId = u.UserId,
                               ans = a.Answer,
                               username = u.Fullname,
                               profileImage = u.ProfileImage,
                               date = a.Date
                           }).ToList();
                if (res != null) return res;
                return res;
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

        Answers IBooksRepository<Answers>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

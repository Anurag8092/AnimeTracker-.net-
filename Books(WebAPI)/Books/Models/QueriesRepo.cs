using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Models
{
    public class QueriesRepo : IBooksRepository<Queries>
    {

        private BooksContext _dbctx;

        public QueriesRepo()
        {
            _dbctx = new BooksContext();
        }

        public QueriesRepo(BooksContext ctx)
        {
            _dbctx = ctx;
        }
        public int Create(Queries createData)
        {
            try
            {
                if (createData != null)
                {
                    _dbctx.Queries.Add(createData);
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

        public List<Queries> GetAll()
        {
            try
            {
                return _dbctx.Queries.OrderByDescending(x => x.QueryId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Queries GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Queries GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Object GetByQueryId(int id)
        {
            try
            {

                var res = (from q in _dbctx.Queries
                           join u in _dbctx.Users on q.UserId equals u.UserId
                           where q.QueryId == id

                           select new
                           {
                             queryId = q.QueryId,
                             userId = u.UserId,
                             query = q.Query,
                             username = u.Fullname,
                             date = q.Date
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

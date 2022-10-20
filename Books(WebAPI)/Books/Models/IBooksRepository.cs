using System.Collections.Generic;

namespace Books.Models
{
    public interface IBooksRepository<T>
    {
        int Create(T createData);
        T GetById(int id);
        T GetByEmail(string email);
        List<T> GetAll();
        int Delete(int id);
        int Update(int id);
    }
}

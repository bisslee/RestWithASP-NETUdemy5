using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        Book FindById(long id);
        List<Book> FindAll();
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);

    }
}

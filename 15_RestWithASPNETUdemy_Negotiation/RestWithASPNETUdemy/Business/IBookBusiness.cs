using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        void Delete(long id);

    }
}

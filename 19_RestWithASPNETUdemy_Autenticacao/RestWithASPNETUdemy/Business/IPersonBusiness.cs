using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IPersonBusiness
    {
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        void Delete(long id);

    }
}

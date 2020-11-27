using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IPersonBusiness
    {
        Person FindById(long id);
        List<Person> FindAll();
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);

    }
}

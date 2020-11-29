using RestWithASPNETUdemy.Data.Converter.Implamentation;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplemantation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplemantation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Create(PersonVO person)
        {
            var entity = _converter.Parse(person);
            return _converter.Parse(_repository.Create(entity));
        }

        public PersonVO Update(PersonVO person)
        {
            var entity = _converter.Parse(person);
            return _converter.Parse(_repository.Update(entity));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}

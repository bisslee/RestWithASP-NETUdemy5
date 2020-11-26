using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplemantation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplemantation(MySQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id==id);
        }

        public Person Create(Person person)
        {

            try
            {
                _context.Add(person);
                _context.SaveChanges();
                return person;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Person Update(Person person)
        {

            var result = FindById(person.Id);
            if (result == null)
            {
                return new Person();
            }

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
                return person;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(long id)
        {
            var result = FindById(id);
            if (result != null)
            {
                _context.Persons.Remove(result);
                _context.SaveChanges();
            }

        }

    }
}

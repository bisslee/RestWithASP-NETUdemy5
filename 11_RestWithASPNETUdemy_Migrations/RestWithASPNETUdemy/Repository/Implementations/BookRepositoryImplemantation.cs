using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class BookRepositoryImplemantation : IBookRepository
    {
        private MySQLContext _context;

        public BookRepositoryImplemantation(MySQLContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id==id);
        }

        public Book Create(Book book)
        {

            try
            {
                _context.Add(book);
                _context.SaveChanges();
                return book;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Book Update(Book book)
        {

            var result = FindById(book.Id);
            if (result == null) return result;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(book);
                _context.SaveChanges();
                return book;
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
                _context.Books.Remove(result);
                _context.SaveChanges();
            }

        }

        public bool Exists(long id)
        {
            return _context.Books.Any(p => p.Id == id);
        }
    }
}

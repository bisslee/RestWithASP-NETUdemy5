using RestWithASPNETUdemy.Data.Converter.Implamentation;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplemantation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;
        public BookBusinessImplemantation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Create(BookVO book)
        {
            var entity = _converter.Parse(book);
            return _converter.Parse(_repository.Create(entity));
        }

        public BookVO Update(BookVO book)
        {
            var entity = _converter.Parse(book);
            return _converter.Parse(_repository.Update(entity));
        }

        public void Delete(long id)
        {
           _repository.Delete(id);
        }

    }
}

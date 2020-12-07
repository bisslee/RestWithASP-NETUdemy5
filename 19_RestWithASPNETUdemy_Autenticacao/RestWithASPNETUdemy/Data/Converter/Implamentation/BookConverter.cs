using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Data.Converter.Contatract;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
namespace RestWithASPNETUdemy.Data.Converter.Implamentation
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;

            return new Book()
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Isbn = origin.Isbn,
                Edition = origin.Edition,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

       

        public BookVO Parse(Book origin)
        {
            return new BookVO()
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Isbn = origin.Isbn,
                Edition = origin.Edition,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }
        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

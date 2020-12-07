using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            var pass = Computehash(user.PassWord, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u=> (u.UserName== user.UserName) && (u.Password == pass) );
        }
        public User ValidateCredentials(string userName)
        {
            return _context.Users.FirstOrDefault(u => (u.UserName == userName));
        }

        public bool RevokeToken(string userName)
        {
            var user =  _context.Users.FirstOrDefault(u => (u.UserName == userName));
            if (user == null) return false;

            user.RefreshToken = null;
            _context.SaveChanges();

            return true;
        }

        public User RefreshUserInfo(User entity)
        {
            var result = _context.Users.SingleOrDefault(u => u.Id == entity.Id);

            if (result== null) return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private string Computehash(string input, SHA256CryptoServiceProvider algorithm)
        {

            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
              
    }
}

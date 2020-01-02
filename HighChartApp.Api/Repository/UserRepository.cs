using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HighChartApp.Api.Data;
using HighChartApp.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace HighChartApp.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User newUser)
        {
            var result = await _context.AppUsers.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> GetByEmail(string email)
        {
            var result = await _context.AppUsers.Where(x => x.Email == email && x.IsEmailVerified).FirstOrDefaultAsync();
            return result;
        }

        public async Task<User> GetByUsername(string username)
        {
            var result = await _context.AppUsers.Where(x => x.UserName == username).FirstOrDefaultAsync();
            return result;
        }

        public async Task<User> GetLogin(string username, string password)
        {
            var result = await _context.AppUsers.Where(x => x.UserName == username && x.Password == password).FirstOrDefaultAsync();
            return result;
        }

        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            var userInfo = await GetByUsername(username);
            //if (userInfo == null)
            //{
            //    userInfo = await GetByEmail(username);
            //}

            var hashedPassword = EncriptPassword(password);

            if (userInfo.Password == password)
            {
                return userInfo;
            }
            else
            {
                return null;
            }
        }

        private string EncriptPassword(string password)
        {
            SHA256 sha = new SHA256Managed();
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(data);
        }
    }
}

using HighChartApp.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighChartApp.Api.Repository
{
    public interface IUserRepository
    {
        Task<User> GetByUsername(string username);
        Task<User> GetByEmail(string email);
        Task<User> GetLogin(string username, string password);
        Task<User> GetUserByUsernameAndPassword(string username, string password);
        Task<User> AddUser(User newUser);
    }
}

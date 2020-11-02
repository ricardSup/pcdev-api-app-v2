using System.Collections.Generic;
using System.Linq;
using JwtAuthDemo.DataAccess;
using JwtAuthDemo.Models;
using Microsoft.Extensions.Logging;

namespace JwtAuthDemo.Services
{
    public interface IUserService
    {
        bool IsAnExistingUser(string userName);
        bool IsValidUserCredentials(string userName, string password);
        string GetUserRole(string userName);
    }

    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly PostgreSqlContext _context;

        private readonly IDictionary<string, string> _users = new Dictionary<string, string>
        {
            { "test1", "password1" },
            { "test2", "password2" },
            { "admin", "securePassword" }
        };
        // inject your database here for user validation
        public UserService(ILogger<UserService> logger, PostgreSqlContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public bool IsValidUserCredentials(string userName, string password)
        {
            _logger.LogInformation($"Validating user [{userName}]");
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return _users.TryGetValue(userName, out var p) && p == password;
        }

        public bool IsAnExistingUser(string userName)
        {
            //return _users.ContainsKey(userName);
            User user = _context.Users.FirstOrDefault(t => t.UserName == userName);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string GetUserRole(string userName)
        {
            if (!IsAnExistingUser(userName))
            {
                return string.Empty;
            }

            //if (userName == "admin")
            //{
            //    return UserRoles.Admin;
            //}

            //return UserRoles.BasicUser;

            Role usrrole = (from user in _context.Users
                        join userrole in _context.UserRoles on user.UserLoginId equals userrole.UserId
                        join role in _context.Roles on userrole.RoleId equals role.RoleId
                        where user.UserName == userName
                        select role).FirstOrDefault();
            if (usrrole == null)
            {
                return string.Empty;
            }
            else
            {
                return usrrole.Name;
            }
        }
    }

    public static class UserRoles
    {
        public const string Admin = nameof(Admin);
        public const string BasicUser = nameof(BasicUser);
    }
}

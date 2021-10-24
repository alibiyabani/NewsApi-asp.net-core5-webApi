using NewsApi.Core.Services.Interfaces;
using NewsApi.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Services
{
    public class UserService : IUserService
    {
        private ApiContex _context;

        public UserService(ApiContex contex)
        {
            _context = contex;
        }

        public bool IsExist(string userName, string password)
        {
            return _context.Users.Any(u => u.UserName == userName && u.Password == password);
        }

    }
}

using Microsoft.Extensions.Options;
using PumoxBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumoxBackend.Services
{
    public interface IUserService
    {
        bool Authenticate(string username, string password);
    }
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public bool Authenticate(string username, string password)
        {
            return username == _appSettings.user && password == _appSettings.password ? true : false;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using DNSAPI.Model;

namespace DNSAPI.Service.Interface
{
    public interface IUserService
    {
        List<User> GetUserList();

        Task<User> GetToken(string username, string password);

        void InsertUser(string username, string password);
    }
}
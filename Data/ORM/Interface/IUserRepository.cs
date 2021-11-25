using DNSAPI.Model;
using System.Threading.Tasks;

namespace DNSAPI.Data.ORM.Interface
{
    public interface IUserRepository
    {
        Task<User> ValidateUser(string username, string password);

        void InsertUser(string username, string password);
    }
}
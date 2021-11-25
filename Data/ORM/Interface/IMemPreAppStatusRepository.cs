using DNSAPI.Model;
using System.Threading.Tasks;

namespace DNSAPI.Data.ORM.Interface
{
    public interface IMemPreAppStatusRepository
    {
        Task<PreAppStatus> GetMemPreAppStatus(string Id);
    }
}
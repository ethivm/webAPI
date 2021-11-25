using DNSAPI.Model;
using System.Threading.Tasks;

namespace DNSAPI.Data.ORM.Interface
{
    public interface IMemReimpStatusRepository
    {
        Task<ReimpStatus> GetmemReimpStatus(string Id);
    }
}
using DNSAPI.Model;
using System.Threading.Tasks;

namespace DNSAPI.Data.ORM.Interface
{
    public interface IMemDetailsRepository
    {
        Task<MemberDetails> GetmemDetails(string Id);
    }
}
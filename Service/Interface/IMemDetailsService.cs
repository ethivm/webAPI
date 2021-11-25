using System.Collections.Generic;
using System.Threading.Tasks;
using DNSAPI.Model;

namespace DNSAPI.Service.Interface
{
    public interface IMemDetailsService
    {
       Task<MemberDetails> GetmemDetails(string Id);
    }
}
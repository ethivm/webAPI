using System.Collections.Generic;
using System.Threading.Tasks;
using DNSAPI.Model;

namespace DNSAPI.Service.Interface
{
    public interface IProviderService
    {
       Task<List<Provider>> GetMemberNetwork(string Id);
    }
}
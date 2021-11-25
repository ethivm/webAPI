using DNSAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNSAPI.Data.ORM.Interface
{
    public interface IProviderRepository
    {
        Task<List<Provider>> GetMemberNetwork(string Id);
    }
}
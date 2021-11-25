using System.Collections.Generic;
using System.Threading.Tasks;
using DNSAPI.Model;

namespace DNSAPI.Service.Interface
{
    public interface IMemPreAppStatusService
    {
       Task<PreAppStatus> GetMemPreAppStatus(string Id);
    }
}
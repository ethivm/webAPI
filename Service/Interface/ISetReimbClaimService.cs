using System.Collections.Generic;
using DNSAPI.Model;

namespace DNSAPI.Service.Interface
{
    public interface ISetReimbClaimService
    {
        void SetReimbClaim(ReimbClaim request);
    }
}
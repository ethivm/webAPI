using DNSAPI.Model;

namespace DNSAPI.Data.ORM.Interface
{
    public interface ISetReimbClaimRepository
    {
        void SetReimbClaim(ReimbClaim request);
    }
}
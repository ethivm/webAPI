using System.Collections.Generic;
using DNSAPI.Data.ORM.Interface;
using DNSAPI.Model;
using DNSAPI.Utils;
using DNSAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DNSAPI.Service.Class
{
    public class SetReimbClaimService : ISetReimbClaimService
    {
        private readonly ISetReimbClaimRepository _setReimbClaimRepository;
        public SetReimbClaimService(ISetReimbClaimRepository setReimbClaimRepository
            )
        {
            _setReimbClaimRepository = setReimbClaimRepository;
        }

        public void SetReimbClaim(ReimbClaim request)
        {
            try
            {
                _setReimbClaimRepository.SetReimbClaim(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
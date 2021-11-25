using System.Collections.Generic;
using DNSAPI.Data.ORM.Interface;
using DNSAPI.Model;
using DNSAPI.Utils;
using DNSAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace DNSAPI.Service.Class
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        public ProviderService(IProviderRepository providerRepository
            )
        {
            _providerRepository = providerRepository;
        }

        public async Task<List<Provider>> GetMemberNetwork(string Id)
        {
            try
            {
                return await _providerRepository.GetMemberNetwork(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

    }
}
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
    public class MemDetailsService : IMemDetailsService
    {
        private readonly IMemDetailsRepository _memDetailsRepository;
        public MemDetailsService(IMemDetailsRepository memDetailsRepository
            )
        {
            _memDetailsRepository = memDetailsRepository;
        }

        public async Task<MemberDetails> GetmemDetails(string Id)
        {
            try
            {
                return await _memDetailsRepository.GetmemDetails(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
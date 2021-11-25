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
    public class MemReimpStatusService : IMemReimpStatusService
    {
        private readonly IMemReimpStatusRepository _memReimpStatusRepository;
        public MemReimpStatusService(IMemReimpStatusRepository memReimpStatusRepository
            )
        {
            _memReimpStatusRepository = memReimpStatusRepository;
        }

        public async Task<ReimpStatus> GetmemReimpStatus(string Id)
        {
            try
            {
                return await _memReimpStatusRepository.GetmemReimpStatus(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
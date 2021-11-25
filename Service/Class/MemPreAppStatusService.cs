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
    public class MemPreAppStatusService : IMemPreAppStatusService
    {
        private readonly IMemPreAppStatusRepository _memPreAppStatusRepository;
        public MemPreAppStatusService(IMemPreAppStatusRepository memPreAppStatusRepository
            )
        {
            _memPreAppStatusRepository = memPreAppStatusRepository;
        }

        public async Task<PreAppStatus> GetMemPreAppStatus(string Id)
        {
            try
            {
                return await _memPreAppStatusRepository.GetMemPreAppStatus(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
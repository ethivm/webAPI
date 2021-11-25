using Dapper;
using System.Data;
using System.Linq;
using DNSAPI.Data.ORM.Interface;
using DNSAPI.Model;
using System.Threading.Tasks;
using System;

namespace DNSAPI.Data.ORM.Class
{
    public class MemPreAppStatusRepository : BaseRepository, IMemPreAppStatusRepository
    {
        public async Task<PreAppStatus> GetMemPreAppStatus(string id)
        {
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"
                select top 1 ENT148_01 as PreAuthReferralID,ENT148_05 as PreAuthServiceDate,ENT111_03 as ProviderName,ENT113_02 as DoctorName,ENT148_16 as PreAuthStatus from ENT127 inner join ENt148 on ENT148.ENT127_01=ENT127.ENT127_01 inner join ENt111 on ENT148.ENT111_01=ENT111.ENT111_01 inner join ENt113 on ENT148.ENT113_01=ENT113.ENT113_01 where  ENT148_16<>'Pending Submission' and ENT148_16<>'Edited' and ENT127_13='true' and convert(date,ENT127_10)>=convert(date,getdate())
                and ENT127_02 = @id";

                    var result = await db.QueryAsync<PreAppStatus>(sql, new { id }).ConfigureAwait(false);
                    return result.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
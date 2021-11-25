using Dapper;
using System.Data;
using System.Linq;
using DNSAPI.Data.ORM.Interface;
using DNSAPI.Model;
using System.Threading.Tasks;
using System;

namespace DNSAPI.Data.ORM.Class
{
    public class MemReimpStatusRepository : BaseRepository, IMemReimpStatusRepository
    {
        public async Task<ReimpStatus> GetmemReimpStatus(string Id)
        {
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"select top 1 ENT128_01 as [ClaimDocumentCode],ENT128_03 as [EntryDate],ENT128_12 as [ConsultationDate],(case when ENT128_41 is not null then 'PAID' when ENT128_22='true' then 'Processed' else 'Processing' end) as [Status]  from ENT127 inner join ENt128 on ENT128.ENT127_01=ENT127.ENT127_01 where ENT128_29='REM' and ENT127_13='true' and convert(date,ENT127_10)>=convert(date,getdate())
                     and ENT127_02 = @Id";

                    var result = await db.QueryAsync<ReimpStatus>(sql, new { Id }).ConfigureAwait(false);
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
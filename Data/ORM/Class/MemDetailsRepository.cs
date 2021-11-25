using Dapper;
using System.Data;
using System.Linq;
using DNSAPI.Data.ORM.Interface;
using DNSAPI.Model;
using System.Threading.Tasks;
using System;

namespace DNSAPI.Data.ORM.Class
{
    public class MemDetailsRepository : BaseRepository, IMemDetailsRepository
    {
        public async Task<MemberDetails> GetmemDetails(string id)
        {
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"select top 1 ENT127_02 as MemberID,ENT127_03 as MemberName,ENT127_04 as DOB,ENT127_05 as Gender,ENT127_09 as EffDate,ENT127_10 as ExpDate,ENT127_27 as EID,ENT127_30 as MStatus,ENT127_56 as PolNo,ENT122_02 as NetworkName from dbo.ENT127 inner join dbo.ENt125 on ENT125.ENT125_01=ENT127.ENT125_01 inner join dbo.ENt122 on ENT125.ENT122_01=ENT122.ENT122_01 
                  where 
                ENT127_13='true' and convert(date,ENT127_10)>=convert(date,getdate())
and (ENT127_02 = @id  or ENT127_27= @id or ENT127_56= @id)  ";

                    var result = await db.QueryAsync<MemberDetails>(sql, new { id }).ConfigureAwait(false);
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
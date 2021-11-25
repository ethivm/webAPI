using Dapper;
using System.Data;
using System.Linq;
using DNSAPI.Data.ORM.Interface;
using DNSAPI.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace DNSAPI.Data.ORM.Class
{
    public class ProviderRepository : BaseRepository, IProviderRepository
    {
        public async Task<List<Provider>>  GetMemberNetwork(string Id)
        {
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"SELECT ENT111.ENT111_14 as ProviderType,
ENT111.ENT111_03 as ProviderName ,ENT122.ENT122_02 as NetworkName, ENT111.ENT111_04 as Place, ENT111.ENT111_10 as Address FROM ENT111_11 INNER JOIN ENT111 ON ENT111_11.ENT111_01 = ENT111.ENT111_01 INNER JOIN  ENT122 ON ENT111_11.ENT122_01 = ENT122.ENT122_01 where ENT111_11.ENT122_01 = (select top 1 ENT122_01 from ENT125 inner join ENT127 on ENT125.ENT125_01 = ENT127.ENT125_01  WHERE convert(date, ENT127_10) >= convert(date, getdate())
and (ENT127_02= @Id or ENT127_27 = @Id)
)";

                    var result = await db.QueryAsync<Provider>(sql, new { Id }).ConfigureAwait(false);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
    }
}
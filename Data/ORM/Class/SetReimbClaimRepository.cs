using Dapper;
using System.Data;
using System.Linq;
using DNSAPI.Data.ORM.Interface;
using DNSAPI.Model;
using System;

namespace DNSAPI.Data.ORM.Class
{
    public class SetReimbClaimRepository : BaseRepository, ISetReimbClaimRepository
    {
        public void SetReimbClaim(ReimbClaim request)
        {
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"insert into ENT170 (ENT170_02,ENT170_03,ENT170_04,ENT170_05) values (@MemberID, @DOS, @Amount, @doc)";

                    db.Execute(sql, new { ENT170_02 = request.MemberID, ENT170_03 = request.DOS, ENT170_04 = request.Amount, ENT170_05 = request.doc }, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        
    }
}
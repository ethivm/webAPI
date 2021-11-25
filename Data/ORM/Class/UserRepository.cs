using Dapper;
using System.Data;
using System.Linq;
using DNSAPI.Data.ORM.Interface;
using DNSAPI.Model;
using System;
using System.Threading.Tasks;

namespace DNSAPI.Data.ORM.Class
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public async Task<User> ValidateUser(string username, string password)
        {
            try
            {
                using (var db = GetIdentityConnection())
                {
                    const string sql = @"select Id, Name, Surname, Email, Phone, LastLogon, CreatedOn, ActivationCode
                from dbo.[User] U
                where Login = @Login and Password = @Password";

                    var result= await db.QueryAsync<User>(sql, new { Login = username, Password = password });
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void InsertUser(string username, string password)
        {
            try
            {
                using (var db = GetIdentityConnection())
                {
                    const string sql = @"insert into dbo.[User] (Login, Password, CreatedOn, LastLogon) values (@Login, @Password, getdate(), getdate())";

                    db.Execute(sql, new { Login = username, Password = password }, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
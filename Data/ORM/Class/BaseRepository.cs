using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.IO;

namespace DNSAPI.Data.ORM.Class
{
    public class BaseRepository
    {
        public static IConfigurationRoot Configuration { get; set; }

        public MySqlConnection GetMySqlConnection(bool open = true,
            bool convertZeroDatetime = false, bool allowZeroDatetime = false)
        {
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

                Configuration = builder.Build();

                string cs = Configuration["Logging:AppSettings:MySqlConnectionString"];

                var csb = new MySqlConnectionStringBuilder(cs)
                {
                    AllowZeroDateTime = allowZeroDatetime,
                    ConvertZeroDateTime = convertZeroDatetime
                };
                var conn = new MySqlConnection(csb.ConnectionString);
                if (open) conn.Open();
                return conn;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        public SqlConnection GetSqlConnection(bool open = true,
                bool convertZeroDatetime = false, bool allowZeroDatetime = false)
        {

            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");

                Configuration = builder.Build();

                string cs = Configuration["Logging:AppSettings:SqlConnectionString"];

                var conn = new SqlConnection(cs);
                
                if (open) conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public SqlConnection GetIdentityConnection(bool open = true,
                bool convertZeroDatetime = false, bool allowZeroDatetime = false)
        {

            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");

                Configuration = builder.Build();

                string cs = Configuration["Logging:AppSettings:IdentityConnectionString"];

                var conn = new SqlConnection(cs);
                if (open) conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
using System.Collections.Generic;
using DNSAPI.Data.ORM.Interface;
using DNSAPI.Model;
using DNSAPI.Utils;
using DNSAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DNSAPI.Service.Class
{
    public class UserService : IUserService
    {
        private readonly Tokens _tokenConfigurations;
        private readonly SigningTokenConfigurations _signingConfigurations;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository
            ,[FromServices] SigningTokenConfigurations signingConfigurations,
             [FromServices] Tokens tokenConfigurations
            )
        {
            _userRepository = userRepository;
            _tokenConfigurations = tokenConfigurations;
            _signingConfigurations = signingConfigurations;
        }

        public List<User> GetUserList()
        {
            var obj = new List<User>();
            return obj;
        }

        public async Task<User> GetToken(string username, string password)
        {
            try
            {
                var passwordHash = Utils.HashUtil.GetSha256FromString(password);

                var ret = await _userRepository.ValidateUser(username, passwordHash);

                if (ret != null)
                {
                    var _tokenHandler = new TokenHandler();
                    Token tokenvalue = _tokenHandler.GenerateToken(username, _signingConfigurations, _tokenConfigurations);
                    ret.Token = tokenvalue.AccessToken;
                }
                return ret;
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
                var passwordHash = Utils.HashUtil.GetSha256FromString(password);

                _userRepository.InsertUser(username, passwordHash);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
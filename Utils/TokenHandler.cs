using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using DNSAPI.Model;

namespace DNSAPI.Utils
{

    //public interface ITokenHandler
    //{
    //    object GenerateToken(string username);
    //}
    public class TokenHandler //: ITokenHandler
    {
        //private readonly TokensConfigurations _tokenConfigurations;
        //private readonly SigningTokenConfigurations _signingConfigurations;
        
        //public TokenHandler(TokensConfigurations tokenConfigurations
        //    , SigningTokenConfigurations signingConfigurations)
        //{
        //    _tokenConfigurations = tokenConfigurations;
        //    _signingConfigurations = signingConfigurations;
        //}

        //public TokenHandler([FromServices] SigningTokenConfigurations signingConfigurations,
        //     [FromServices] TokensConfigurations tokenConfigurations)
        //{
        //    _tokenConfigurations = tokenConfigurations;
        //      _signingConfigurations = signingConfigurations;
        //}

        public Token GenerateToken(string username,SigningTokenConfigurations signingConfigurations,
             Tokens tokenConfigurations)
        {
            //var _tokenConfigurations = new TokensConfigurations();
            //var _signingConfigurations = new SigningTokenConfigurations();

            string userId = username;

            var identity = new ClaimsIdentity(
                       new GenericIdentity(userId, "Login"),
                       new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userId)
                       }
                   );

            var dtCreation = DateTime.Now;
            var dtExpiration = dtCreation + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dtCreation,
                Expires = dtExpiration
            });
            var token = handler.WriteToken(securityToken);

            return new Token
            {
                Authenticated = "true",
                Created = dtCreation.ToString("yyyy - MM - dd HH: mm:ss"),
                Expiration = dtExpiration.ToString("yyyy - MM - dd HH: mm:ss"),
                AccessToken = token,
                Message = "OK"
            };


        }
    
    
    }
}

using Balance.Application.Dtos;
using Balance.Core.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _key;

        public AuthService(string key)
        {
            _key = key;
        }
        public Task<AuthTokenDto> GetToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenExpires = DateTime.Now.AddDays(30);

            var symmetricSecurityKey = new SymmetricSecurityKey(tokenKey);
            var cred = new SigningCredentials(
                        key: symmetricSecurityKey,
                        algorithm: SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: cred,
                expires: tokenExpires
                );
            var strToken = tokenHandler.WriteToken(token);

            
            var tokenResponse = new AuthTokenDto()
            {
                Token = strToken,
                Firstname = user.Firstname,
                Lastname = user.Lastname
            };

            return Task.FromResult(tokenResponse);
        }
    }
}

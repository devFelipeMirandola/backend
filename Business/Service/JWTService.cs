using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using reposbackend.Business.Interface;
using reposbackend.Infra;

namespace reposbackend.Business.Service
{
    public class JWTService : IJWTService
    {
        private readonly JwtSettings _jwtSettings;

        public JWTService(JwtSettings settings)
        {
            this._jwtSettings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public JsonWebToken CreateJsonWebToken(List<Claim> claims)
        {
            var handler = new JwtSecurityTokenHandler();

            var payload = new JwtPayload(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims,
                notBefore: _jwtSettings.NotBefore,
                issuedAt: _jwtSettings.IssuedAt,
                expires: _jwtSettings.AccessTokenExpiration
                );

            var jwtSecurity = new JwtSecurityToken(new JwtHeader(_jwtSettings.SigningCredentials), payload);

            var accessToken = handler.WriteToken(jwtSecurity);

            return new JsonWebToken
            {
                AccessToken = accessToken,
                ExpiresIn = DateTime.UtcNow.AddMinutes(_jwtSettings.ValidForMinutes)              
            };
        }
    }
}
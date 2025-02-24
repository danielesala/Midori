using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using auth_api.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace auth_api.Services
{
    public class AuthService(IOptions<JwtKeySettings> jwtKeySettings) : IAuthService
    {
        
        private readonly JwtKeySettings _jwtKeySettings = jwtKeySettings.Value;

        public string GenerateJwtToken(string email, string password)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            
            var privateKey = _jwtKeySettings.PrivateKey;
            using var rsa = RSA.Create();
            rsa.ImportFromPem(privateKey);

            var credentials = new SigningCredentials(
                new RsaSecurityKey(rsa),
                SecurityAlgorithms.RsaSha256
            );

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Email, email),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = "http://localhost:5000",
                Audience = "http://localhost:5000",
                SigningCredentials = credentials
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

using Dominio.Servicio.DTO;
using Dominio.Servicio.Servicios.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.Servicios
{
    public  class TokenService : ITokenService
    {
         
        private readonly SymmetricSecurityKey _ssKey;
        private readonly IConfiguration _config;
       
        public TokenService(IConfiguration config)
        {
            _config = config;
                       
            _ssKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:key"]));

        }

        public string GetToken(AutenticationDto usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Token:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
        new Claim(ClaimTypes.Name, usuario.Nombre)
    }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _config["Token:Issuer"],
                Audience = _config["Token:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

    }
}

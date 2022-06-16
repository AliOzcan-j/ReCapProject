using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Helpers.Abstract;
using Core.Utilities.Helpers.Concrete;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }//WebApi appsettings.json daki bilgileri okumak için
        private TokenOptions _tokenOptions;//Configuration dan gelen bilgileri _tokenOptions nesnesine atayacaz
        DateTime _accessTokenExpiration;//Geçersiz kılma süresini constructor da set ediyoruz, istem yapıldığı andaki tarih değerine belirlenen zamanı ekliyor

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;//bilgiler okundu
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();//nesneye atandı
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//Token geçerlilik süresi belirlendi
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//güvenlik anahtarını oluşturur
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);//Cipher oluşturulur
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);//JWT oluşturur
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);//Nu noktada elimizdeki bilgilerle bir token oluşturuluyor

            //Oluşturulan token'ı ve geçerlilik süresini gönderiyor
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        //JWT Token ın oluşturulduğu method
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires:_accessTokenExpiration,
                notBefore:DateTime.Now,
                claims:SetClaims(user, operationClaims),
                signingCredentials:signingCredentials
                );
            return jwt;
        }

        //Claim basitçe bir key ve value dan oluşan veri, bu key tablodaki id olarak düşünülebilir ancak tablodaki veriden farklı olarak verinin key i value'nun ne olduğunu belirtiyor; başlık gibi.
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());//extension sınıfında oluşturulan claim tipleri
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            
            return claims;
        }
    }
}

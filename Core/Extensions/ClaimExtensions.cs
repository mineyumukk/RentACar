using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    //Var olan bir nesneye yeni metotlar eklememizi sağlayan extenstions metodu
    public static class ClaimExtensions
    {
        //this ICollection<T> yapısı oluşturduğumuz metodun T nesnesine eklenmesini sagliyor. 
        //ICollection ve claim yapısı .Net'e ait.Bizim oluşturduğumuz şeyler değil
        public static void AddEmail(this ICollection<Claim> claims, string email)//email parametreler
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}

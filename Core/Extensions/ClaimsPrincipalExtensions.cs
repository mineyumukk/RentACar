using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        //Kullanıcının JWTdan gelen claimlerini okumak için .Nete ait olan claimsprincipal classı extent ediyoruz.
        //Her bir kullanıcın rollerine göre tek tek yazmak yerine böyle bir sınıf oluşturuyoruz.
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }
        //ClaimRoles metotunu kullandığımız anda direkt rolleri döndürür.
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}

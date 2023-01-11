using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //appsetting.json da oluşturduğumuz stringi byte array haline getiren kod
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            //SymmetricSecurityKey byte'ını alıp simetrik anahtar haline getiriyor
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
//Oluşturduğumuz bu iki yapı JWTın ihtiyaç duyduğu yapılar
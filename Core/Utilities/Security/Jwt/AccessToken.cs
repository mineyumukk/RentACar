using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    //AccessToken ---> Erişim anahtarı
    public class AccessToken
    {
        //Kullanıcı api üzerinden kullanıcı adı ve parolasını girdiği anda sistem ona bir token olusturur.
        public string Token { get; set; }//Jwt değerinin kendisi
        public DateTime Expiration { get; set; }// Bitiş zamanı. Olusturulan tokenın ne zaman sonlanacığı
    }
}

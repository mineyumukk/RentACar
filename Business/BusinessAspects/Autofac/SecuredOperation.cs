using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        //SecuredOperation Jwt için, kullanıcının yetkisi var mı yok mu kontrolü sağlanıyor. 
        private string[] _roles;
        //JWTı göndererek bir istek yaptığımız anda her bir istek için HttpContext oluşur.Her isteğe o anda bir tred oluşur.
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            //Rolleri virgülle ayırıyoruz.SecuredOperation bir attribute olduğu için başka şansımız yok.
            _roles = roles.Split(',');//roles.Split metni benim belirttiğim karaktere göre ayırıp arraye atıyor.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        //Methodun önünde çalıştır demek.Örneğin ekleme metoduna yazdığımız için onun önünde çalıştıracak.Yetkisi var mı bak anlamına da gelebilir
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)//Yetkinin olup olmadığını kontrol eden kısım
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);//Yetkinin olmadığı mesajını döndürür en sonunda
        }
    }
}

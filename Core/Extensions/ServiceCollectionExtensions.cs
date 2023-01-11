using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //DependencyInjection için yapıyoruz.
        //Extent sınıfı oluşturduk ki istediğimiz kadar CoreModule'ı startupa ekleyebilelim.
        //Core katmanı da dahil olmak üzere ekleyeceğimiz bütün injectionları bir arada toplayabileceğimiz bir yapı oluşturduk.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, 
            ICoreModule[] modules)
        {
            foreach (var module in modules)//Modüllerdeki eklenen herbir modul için modülü yükle 
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
//Çok güzel poliformizim örneği
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); //MemoryCacheManager sınıfındaki IMemoryCache interface'ini iplemente etmek için oluşturduk.
                                                //_memoryCache'in karşılığı da denebilir.
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//Arkaplanda HttpContextAccessor instance'ı oluştur demek. 
            //Alttaki kod kendi oluşturdğumuz ICacheMAnager interface'ini enjekte etmek istediğimiz zaman bunun karşılığı 
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();

        }
    }
}

using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {//Data bozulduğu an çalışır. Data güncellenirse, silinirse, yeni data eklenirse data bozulur.
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)//Burada da string değer olarak pattern'ı constructor da tanımladık.
        {
            _pattern = pattern;//pattern set edildi.
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)//ekleme işlemi hata verebilir veri tabanına yeni ürün eklenmeyebilir.
        //Veri tabanına yeni ürün eklenmemişse oluşturulan cache'i silmeye gerek kalmaz. Bu yüzden OnSuccess metodunu kullandık.
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
//2.45i tekrar dinle

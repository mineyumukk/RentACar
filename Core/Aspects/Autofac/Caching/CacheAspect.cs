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
    //Herhangi bir metodun başına yazdığımız anda metot çalışmadan önce bu kodlar çalışır.
    //CacheAspect bir attribute onu da methodinterception olmasından anlıyoruz. 
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;
        //Durationa constructor da default değer verdik.
        public CacheAspect(int duration = 60)//Verinin cache'te durma süresi 60 dk.
        {
            _duration = duration; //Duration set edildi
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //methodName oluşturan key'in method ismi
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//ReflectedType bütün namespace ismini al demek
            //yukarıda en sonda yazdığımız süslü parantez içindeki yer çalıştırdığımız methodun ismini al demek
            var arguments = invocation.Arguments.ToList(); //argument => parametre , invocation=> method demek
            //yukarıda metodun parametrelerini listeye çevir demek istiyoruz.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";// İki soru işareti varsa ilk değeri ypksa ikinci değeri ekle demek.
            //yukarıdaki kod da key oluşturmamıza yarar. Metodun parametrelerini tek tek, eğer ki parametre değeri varsa o parametre değerlerini yukarıda oluşturduğumuz metodun içine ekliyoruz.
            //Yoksa null geç diyoruz
            if (_cacheManager.IsAdd(key))//Bellekte oluşturulan cache anahtarı daha önce oluşturulmuş mu,var mı yok mu kontrol et
            {
                invocation.ReturnValue = _cacheManager.Get(key);//Cache önceden oluşturulmuşsa metodu çalıştırmadan geri dön anlamına gelir.
                //ReturnValue ile manuel bir return oluşturmuş olduk.
                //ReturnValue cacheManagerden get edilen anahtar değerine eşitledik
                return;
            }
            invocation.Proceed();//o değer yoksa invocation'ı çalıştır, metodu devam ettir anlamına gelir.
            //Method çalıştığı an veritabanından datayı getirdi
            _cacheManager.Add(key, invocation.ReturnValue, _duration);//Son olarak burada da cache, değerleri ile birlikte eklenmiş olur.
        }
    }
}

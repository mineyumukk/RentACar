using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    //Bu kurmuş olduğumuz interface bütün alternatiflerin interfaci olur.Ben memory kullandım. Başka bir alternatifte ekleyebiliriz.Bkz:Redis
    public interface ICacheManager
    {
        //Cache'ten gelen datalara hangi tiple çalıştığımızı ve hangi tipe dönüşmesi gerektiğini belirtmiş oluruz.
        T Get<T>(string key);//Verilen keylere karşı Cache'ten data getir.
        object Get(string key);//Yukaridakinin generik olmayan karşılığı
        //Cache'e bir şeyler ekle. Duration bu cache'te ne kadar durabilir.
        void Add(string key, object value, int duration);
        bool IsAdd(string key);//Cache'te var mı sorusunun karşılığı
        void Remove(string key);//Verilen key değerini cache'ten uçur.
        void RemoveByPattern(string pattern);//bazı değerlerin varlığına göre pattern'i cache'ten uçur. 

    }
}

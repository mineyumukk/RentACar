using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);//Genel bağımlılıkları yükler.
    }
}
//AutofacBusinessModule sadece business katmanındaki bağımlılıkları çözer bu interface ise genel bağımlılıkları yükler.
//ServiceTool'u .Net'in kendi altyapısını kullandığımız tekniklerle oluşturduk.
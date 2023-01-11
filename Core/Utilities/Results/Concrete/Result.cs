using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success)
        {
            Message = message;
        }

        public Result(bool success)//Overloading 
        {
            Success = success;
        }

        //Sadece getter kullandığımız için lambda kullandı başta
        public bool Success { get; }

        public string Message { get; } //getter read onlydir ve constructurda set edilebilir.
    }
}

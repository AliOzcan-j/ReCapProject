using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T>:DataResult<T>
    {//API da ihtiyaç duyulabilecek tüm Result işlemleri Error ve Success sınıfları için ayrı yazıldı
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(T data) : base(data, false)
        {
        }

        public ErrorDataResult(string message) : base(default,false, message)
        {
        }

        public ErrorDataResult():base(default,false)
        {
        }
    }
}

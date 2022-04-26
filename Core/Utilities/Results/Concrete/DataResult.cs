using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T>:Result, IDataResult<T>
    {//işlem sonucunun yanında data dönmesi isteniyorsa referansını tutan sınıfları kullanılır
        public DataResult(T data, bool success, string message) : base(success, message)
        {//mesaj dönmesi isteniyorsa buraya, 2 parametre geldiyse aşağıdaki metoda yönlendirir
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {//sonuç ve data dönderir, yalnızca sonuç ise base sınıftaki(Result) metoda yönlendirir
            Data = data;
        }

        public T Data { get; }
    }
}

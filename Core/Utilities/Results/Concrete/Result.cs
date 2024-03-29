﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class Result:IResult
    {
        public Result(bool success, string message):this(success)
        {//Mesajı ve sonucu dönderir. Yalnızca sonuç isteniyorsa this(success) aşağıdaki metoda yönlendirir
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message { get; }
    }
}

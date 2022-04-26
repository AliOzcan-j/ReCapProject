using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{//boolean işlem sonucunu ve mesajı veya yalnızca işlem sonucunu dönderir
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}

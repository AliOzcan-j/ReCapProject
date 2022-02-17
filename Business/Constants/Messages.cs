using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Yeni araba eklendi";
        public static string CarRemoved = "Araba kaydı silindi";
        public static string InvalidCarNameInput = "Araba ismi en az 2 karakterden oluşmalı";
        public static string InvalidBrandId = "Brand id bulunamadı";
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;


/*Attributelara reqiured etiketi atanmayacak, bu doğrulama core katmanındaki 
  interceptor sınıflarıyla yapılacak*/
namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}

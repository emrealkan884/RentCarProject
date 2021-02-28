
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int CarId { get; set; } 
        public int BrandId { get; set; }//Brand = Marka
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }// DailyPrice = Günlük fiyat
        public string Description { get; set; }//Descrition = Açıklama

    }
}

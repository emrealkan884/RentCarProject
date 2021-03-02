using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages//Sürekli new lememek için static verdik.
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarDontAdded = "Araç ismi en az 2 karakter olmalıdır ve günllük fiyatı 0 TL'den fazla olmalıdır";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Araçlar listelendi";
    }
}

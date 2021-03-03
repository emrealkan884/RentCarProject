using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages//Sürekli new lememek için static verdik.
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarNotAdded = "Araç ismi en az 2 karakter olmalıdır ve günllük fiyatı 0 TL'den fazla olmalıdır";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Araçlar listelendi";
        public static string CarUpdated = "Araç güncellendi";
        public static string GetCarsByBrandId = "Araç Marka Id'sine göre getirildi";
        public static string GetCarsByColorId = "Araç Renk Id'sine göre getirildi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string GetUserByUserId = "Kullanıcı Id'sine göre getirildi";
        public static string CustomerUpdated = "Müşter, güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomersListed = "Müşteriler listelendi";
        public static string GetCustomerByCustomerId = "Müşteri Id'sine göre getirildi";
        public static string RentalAdded = "Kiralama eklendi";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalsListed = "Kiralamalar listelendi";
        public static string GetRentalByRentalId = "Kiralama Id'sine göre getirildi";
        public static string RentalNotAdded = "Kiralama eklenmedi";
        


    }
}

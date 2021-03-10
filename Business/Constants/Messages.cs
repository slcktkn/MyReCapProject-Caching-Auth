using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string InvalidName = "Gecersiz isim";
        public static string ValidName = "Tebrikler eklendi";
        public static string MaintenanceTime = "Servis Zamanı";
        public static string LoadedList = "Liste yüklendi";
        public static string GetBrandsById = "ID'lere göre marka detaylarına ulaşıldı";
        public static string GetCarsById = "Araç bilgilerine ulaşıldı";
        public static string CheckIfCarIsValid = "Arac bosta mı kontrol et";
        public static string ErrorReservation = "Baska arac secin";
        public static string MadeReservation = "Rezervasyon yapıldı";
        public static string ListedDetails = "Detay bilgi listelendi";
        public static string CarAddedSuccessfully = "Araç  ekleme basarılı";
        public static string RentalCountOfCarError;
        public static string AddCarImageToList = "Araç resmi ekleyiniz";
        public static string NumberOfCarImageLimitExceeded = "Araç resim limiti aşıldı";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Şifre hatalı";
        public static string SuccessfulLogin="Sisteme giriş başarılı";
        public static string UserAlreadyExists="Kullanıcı zaten mevcut";
        public static string UserRegistered="Kullanıcı başarıyla oluşturuldu";
        public static string AccessTokenCreated="Access Token başarıyla oluşturuldu";
    }
}

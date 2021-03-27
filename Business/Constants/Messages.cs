using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarUpdated = "Araç Güncellendi";
        public static string CarsListed = "Mevcut Araçlar Listeleniyor...";
        public static string CarDeleted = "Araç silindi";
        public static string CheckDailyPrice = "Günlük kira ücreti 0'dan fazla olmalı";
        public static string CarNameInvalid = "Araç ismi minimum 2 karakter olmalıdır";

        public static string BrandAdded = "Marka başarıyla veritabanına eklendi.";
        public static string BrandUpdated = "Marka başarıyla güncellendi.";
        public static string BrandsListed = "Markalar Listeleniyor...";
        public static string BrandDeleted = "Marka başarıyla veritabanından silindi.";

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorListed = "Renkler Listeleniyor...";
        public static string ColorDeleted = "Renk Silindi";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string FirstNameLastNameInvalid = "İsim veya Soyisim Girilmemiş";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserNotDeleted = "HATA. Kullanıcı Silinemedi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UsersListed = "Kullanıcılar Listeleniyor...";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerNotAdded = "HATA. Müşteri Eklenemedi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerNotDeleted = "HATA. Müşteri Silinemedi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomersListed = "Müşteriler Listeleniyor...";

        public static string RentalAdded = "Kiralama Bilgisi Eklendi";
        public static string RentalAddedError = "Araç teslim edilmediği için tekrar kiraya verilemez";
        public static string RentalUpdateReturnDate = "Araç Teslim Alındı";
        public static string RentalUpdateReturnDateError = "Araç Teslim Alınmış";
        public static string RentalUpdated = "Kiralama Bilgisi Güncellendi";
        public static string RentalListed = "Kiralama Bilgileri Listeleniyor...";
        public static string RentalDeleted = "Kiralama Bilgisi Silindi";

        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarImageLimitExceeded = "Fotoğraf yükleme limitine takıldınız. En fazla 5 fotoğraf eklenebilir.";
    }
}

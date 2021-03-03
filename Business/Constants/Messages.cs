using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Eklendi.";
        public static string Deleted = "Silindi.";
        public static string Updated = "Güncellendi.";
        public static string Listed = "Listelendi.";
        public static string InvalidPrice = "Geçersiz ücret.";
        public static string InvalidName = "Geçersiz isim.";
        public static string BrandLimitExceeded = "Bir markadan en fazla 5 adet olabilir.";
        public static string ModelYearExpired = "Arabaların yaşı en fazla 20 olabilir.";
        public static string ImageLimitExceeded = "Bir aracın en fazla 5 resmi olabilir.";
        public static string NoPictures = "Araca ait fotoğraf yok, fotoğraf yerine şirket logosu yüklendi.";
    }
}

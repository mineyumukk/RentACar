using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç başarıyla eklendi.";
        public static string CarDescriptionInvalid = "Araç açıklaması en az 2 karakter olmalıdır.";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarListed =  "Araçlar Listelendi"  ;
        public static string CarDeleted = "Araç silindi.";
        public static string CarUpdated = "Araba başarı ile güncellendi.";

        public static string BrandAdded = "Marka başarıyla eklendi.";
        public static string BrandNameInvalid = "Marka ismi en az 2 karakter olmalıdır.";
        public static string BrandDeleted= "Marka başarıyla silindi.";
        public static string BrandUptated = "Marka başarıyla güncellendi.";
        
        public static string ColorNameInvalid = "Renk ismi en az 2 karakter olmalıdır.";
        public static string ColorAdded = "Renk başarıyla eklendi.";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        
        
        public static string RentalUpdated = "Kiralık Araç Güncellendi";
        public static string RentalDeleted = "Kiralık Araç Silindi";
        public static string RentalAdded = "Kiralık Araç Eklendi";
        public static string RentalListed = "Kiralık Araç Listelendi";
        public static string RentalUpdatedReturnDate = "Araç Teslim Edildi";

        public static string ProductCountOfCategoryError = "Eklenen kategorideki araç en fazla 15 olabilir.";
        public static string CheckIfBrandNameExits= "";
        public static string CheckIfDescriptionExists= "Bu açıklamada zaten başka bir araç var";
        public static string AuthorizationDenied = "Yetkiniz yok!";
        internal static string UserRegistered;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;
    }
}

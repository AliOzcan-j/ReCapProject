using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Constants
{
    public class Messages
    {//Result sınıflarının test edilmesi için, geçici
        public static string CarAdded = "Yeni araba eklendi";
        public static string CarRemoved = "Araba kaydı silindi";
        public static string InvalidCarNameInput = "Araba ismi en az 2 karakterden oluşmalı";
        public static string InvalidBrandId = "Brand id bulunamadı";
        public static string CarDontHaveAnyImages = "Kayıtlı fotoğraf bulunamadı";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError = "Yanlış parola";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkilendirme Başarısız";
    }
}

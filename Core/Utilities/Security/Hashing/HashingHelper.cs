using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {//out keyword'ü C dilindeki adres operatörleri ve pointerlar gibi çalışıyor. Bu keyword kullanıldığında bu nesne üzerindeki değişimler referansın gösterdiği yerdeki verininde değişmesini sağlıyor
     //Yani metoda dönüş tipi verilmeden, doğrudan verinin orjinali üzerinde işlem yapılıyor kopyasında değil
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;//şifreleme sistemimizin belirlenen key'i
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//gelen düz metinden oluşturulan hash değeri
            }
        }

        //Kullanıcının girdiği şifreyi doğru mu
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))//şifre oluşturulurken algoritmaya verilen key verisini tekrar algoritmaya beslediğimizde aynı hash değerini verir. Burda key verimiz passwordSalt diye isimlendirilen değişken
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//gelen düz metin ile yine bir hash oluşturuluyor
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])//bit by bit elimizdeki hash ile oluşturulan hash i karşılaştırarak şifrenin doğru olup olmadığı sorgulanıyor
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

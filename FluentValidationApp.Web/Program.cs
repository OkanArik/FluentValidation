using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/* Bir adet basit bir Asp.Net Core Web App MVC projesi oluþturduk               */
/* Fluent Validation :
 * Bir doðrulama kütüphanesidir.Bizim projemiz içerisinde kullanmýþ olduðumuz 
 property leri doðrulama iþlemini gerçekleþtirir.Fluent validation ile beraber
 hazýr birçok method gelmektedir.
 * Fluent validationla gelen hazýr methodlarý(validator):
 - NotNull Validator
 - NotEmpty Validator
 - NotEqual Validator
 - Equal Validator
 - Length Validator
 - MaxLength Validator
 - MinLength Validator
 - Less Than Validator
 - Less Than Or Equal Validator
 - Greater Than Validator
 - Greater Than Or Equal Validator
 - Predicate Validator
 - Regular Expression Validator
 - Email Validator
 - Credit Card Validator
 - Enum Validator
 - Enum Name Validator
 - Empty Validator
 - Null Validator
 - ExclusiveBetween Validator
 - InclusiveBetween Validator
 - ScalePrecision Validator                                                          */
/* Neden Fluent Validation kullanalým:
 * Separation Of Concern(SoC) prensibine uymuþ oluruz. 
 * Unit Test aþamasýnda bize kolaylýk saðlamaktadýr.                                 */
/* Separation Of Concern(SoC) : SoC (Separation Of Concerns), yazýlýmda iþlev ve 
 özelliklerine göre programlama kodlarýnýn (class, fonksiyon vb.) birbirinden ayrýlmasý/
 soyutlanmasý gerektiðini belirten bir tasarým prensibidir ve günümüzde tercih edilen pek
 çok yazýlým tasarým þablonunun (design pattern) da temelini oluþturur.              */
/* Unit Test(Birim Test) : Birim testi, yazýlým programlamasýnda bir tasarým ve geliþtirme 
 yöntemidir. Bu yöntemde yazýlýmcý yazýlým kodunu oluþturan birimlerin kullanýma hazýr 
 olduðuna iknâ olur. Birim, bir bilgisayar uygulamasýnda test edilebilecek en küçük bölüme 
 denir.                                                                              */
namespace FluentValidationApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

/* Code First : Ýlk olarak uygulama içerisinde entity oluþturup sonra veritabanýnda 
 karþýlýðý olan tabloyu oluþturmaya denir.Migration sayesinde bu uygulamayý gerçekleþtirebiliyoruz.*/
/* Nuget Manager dan dört adet paket yükledik :
 * EntityFrameworkCore => ORM aracý kod ile veritabýn arasýnda iliþki kurup code üzerinden veritabanýnda manipülasyon yapmamýzý saðlar.
 * EntityFrameworkCore.SqlServer => Sql server kullanacaðýmýz için ekledik.
 * EntityFrameworkCore.Tools => Migration iþlemlerini Package Manager Console dan yapabilmemizi saðlar.
 * VisualStudio.Web.CodeGeneration.Design                                              */
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/* Bir adet basit bir Asp.Net Core Web App MVC projesi olu�turduk               */
/* Fluent Validation :
 * Bir do�rulama k�t�phanesidir.Bizim projemiz i�erisinde kullanm�� oldu�umuz 
 property leri do�rulama i�lemini ger�ekle�tirir.Fluent validation ile beraber
 haz�r bir�ok method gelmektedir.
 * Fluent validationla gelen haz�r methodlar�(validator):
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
/* Neden Fluent Validation kullanal�m:
 * Separation Of Concern(SoC) prensibine uymu� oluruz. 
 * Unit Test a�amas�nda bize kolayl�k sa�lamaktad�r.                                 */
/* Separation Of Concern(SoC) : SoC (Separation Of Concerns), yaz�l�mda i�lev ve 
 �zelliklerine g�re programlama kodlar�n�n (class, fonksiyon vb.) birbirinden ayr�lmas�/
 soyutlanmas� gerekti�ini belirten bir tasar�m prensibidir ve g�n�m�zde tercih edilen pek
 �ok yaz�l�m tasar�m �ablonunun (design pattern) da temelini olu�turur.              */
/* Unit Test(Birim Test) : Birim testi, yaz�l�m programlamas�nda bir tasar�m ve geli�tirme 
 y�ntemidir. Bu y�ntemde yaz�l�mc� yaz�l�m kodunu olu�turan birimlerin kullan�ma haz�r 
 oldu�una ikn� olur. Birim, bir bilgisayar uygulamas�nda test edilebilecek en k���k b�l�me 
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

/* Code First : �lk olarak uygulama i�erisinde entity olu�turup sonra veritaban�nda 
 kar��l��� olan tabloyu olu�turmaya denir.Migration sayesinde bu uygulamay� ger�ekle�tirebiliyoruz.*/
/* Nuget Manager dan d�rt adet paket y�kledik :
 * EntityFrameworkCore => ORM arac� kod ile veritab�n aras�nda ili�ki kurup code �zerinden veritaban�nda manip�lasyon yapmam�z� sa�lar.
 * EntityFrameworkCore.SqlServer => Sql server kullanaca��m�z i�in ekledik.
 * EntityFrameworkCore.Tools => Migration i�lemlerini Package Manager Console dan yapabilmemizi sa�lar.
 * VisualStudio.Web.CodeGeneration.Design                                              */
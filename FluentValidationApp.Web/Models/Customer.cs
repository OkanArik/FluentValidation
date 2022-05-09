using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentValidationApp.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //[Required(ErrorMessage ="Name alanı boş olamaz. Attribute'dan geldi.")]
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime? BirthDay { get; set; }
        public IList<Address> Adresses { get; set; } //IList kullanmamızın sebebi Adress bilgilerini index olarak kullanmak için.
                                                     //Customer.Address[0].Name şeklinde kullanabilmek için .
                                                     // IList zaten ICollection dan miras almaktadır.

        public Gender Gender { get; set; }
    }
}

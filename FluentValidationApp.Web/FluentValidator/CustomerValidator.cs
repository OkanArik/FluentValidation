using FluentValidation;
using FluentValidationApp.Web.Models;
using System;

namespace FluentValidationApp.Web.FluentValidator
{
    public class CustomerValidator :AbstractValidator<Customer> // FluentValidation da validation yapacağımız sınıf AbstractValidator dan kalıtım alır ve AbstractValidator<ValideEdilecekSınıf> şeklinde tanımlanır.
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz!";
        public CustomerValidator() // FLuentValidationda validatorlarımızı constructor içerisine tanımlarız.
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(NotEmptyMessage)
                .EmailAddress().WithMessage("Email alanı doğru formatta olmalıdır!");
            RuleFor(x => x.Age)
                .NotEmpty().WithMessage(NotEmptyMessage)
                .InclusiveBetween(18, 60).WithMessage("Age alanı 18 ile 60 arasında olmalıdır!");


            RuleFor(x => x.BirthDay)
                .NotEmpty().WithMessage(NotEmptyMessage)
                .Must(x =>
               {
                   return DateTime.Now.AddYears(-18) >= x;

               }).WithMessage("Yaşınız 18 den büyük olmalıdır");//CustomValidator yazmak için Must methodu kullanılır.
            //Must methodu bool döner.


            RuleForEach(x => x.Adresses).SetValidator(new AddressValidator());


            RuleFor(x => x.Gender).IsInEnum().WithMessage("{PropertyName} alanı Erkek=1, Bayan=2 olmalıdır!");
        }
    }
}

namespace FluentValidationApp.Web.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public virtual Customer Customer { get; set; } //virtual yapmamızın sebebi EntityFramework ilgili Customer üzerinde tracking yani izleme işlemi gerçekleştirebilsin.EntityFramework te yapmış olduğumuz insert update ler önce mermoery de yani hafızada tutulur , ne zamanki SavaChanges() methodunu çağırdık o zaman mermory de tutulan değişiklikler veritabanına yansıtılır.İşte bu Customer üzerinde EntityFramewor kün insert update işlemlerini izleyebilmesi için virtual olarak belirtlememiz gerekmektedir. 
    }
}

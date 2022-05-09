using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationApp.Web.FluentValidator;
using FluentValidationApp.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; } // appsettings.json dan okuyaca��m�z verileri Configuration[] ile okuruz.

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>     // AppDbContext 'imizi projemize service olarak ekledik.
            {
                options.UseSqlServer(Configuration["ConStr"]);
            });

            // services.AddSingleton<IValidator<Customer>, CustomerValidator>(); // Bu �ekilde t�m validator s�n�flar�n� servis olarak tan�tmak gereklidir.

            services.AddControllersWithViews().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<Startup>(); // Bu �ekilde Assembly i�erisindeki t�m IValidator interfacelerine sahib olan classlar�(yani validatorlar�) bulur ve service olarak projeye ekler.
            });// Burada dedikki Startup class�n�n bulundu�u assembly den IValidator interfacelerinden kal�t�m alm�� t�m validator classlar� ekle dedik.

            services.Configure<ApiBehaviorOptions>(options =>  
            {
                options.SuppressModelStateInvalidFilter = true; // Asp.Net Core da default olarak gelen hata mesaj�n� true yaparak bask�lad�k kendimiz custom olarak hata d�nece�iz.
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

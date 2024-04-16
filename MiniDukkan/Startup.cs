using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiniDukkan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDukkan
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; set; }





        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)//Ba��ml�l�k ekleme ve uygulama boyunca eklenecek hizmetleri kullanmak i�in eklenen metod.
       

        {
            
            services.AddControllersWithViews();//MVC framework ve razor sayfalar�n�n gerektirdi�i payla��ml� nesnelerin kullan�m� i�in kullan�l�r
            services.AddDbContext<MiniDukkanContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:MiniDukkanConnection"]));

            services.AddScoped<IDukkanRepository,   EfDukkanRepository>();
        }






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();// Uygulamalarda meydana gelen istisnalar�n ayr�nt�lar�n� g�r�nt�ler. Yaz�l�m geli�tirme a�amas�nda �ok avantajl�d�r. Canl�ya al�nm�� projelerde asla kullan�lmamal9�.
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }




            app.UseStaticFiles();// Bu metod wwwroot klas�r�n�n i�eri�inin kullan�lmas�na olanak sa�lar bu olmazsa ora �al��maz.

            app.UseRouting();



            app.UseStatusCodePages();// HTTP yan�tlar�na basit mesajlar eklemek i�in kullan�l�r. �rne�in 404 sayfas� bulunamayan bir sayfad�r ya buna mesaj eklemeize imkan sunar.
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("katsayfa", "{kategori}/Sayfa{urunSayfa:int}", new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("sayfa" , "Sayfa{urunSayfa:int}", new { Controller ="Home", action = "Index",urunSayfa=1 });

                endpoints.MapControllerRoute("kategoria", "{kategori}", new { Controller = "Home", action = "Index", urunSaya = 1 });

                endpoints.MapControllerRoute("sayfalama", "Urunler/Sayfa{urunSayfa}", new { Controller = "Home", action = "Index" , urunSayfa =1});
                endpoints.MapDefaultControllerRoute();  

                //route sayesinde hem gelen istekleri i�lerken hem de giden url olu�turuyoruz.


            });
            
            Hamveri.VeriDoldur(app);


        }



    }
}

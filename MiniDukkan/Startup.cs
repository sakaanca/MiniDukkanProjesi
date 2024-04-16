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
        public void ConfigureServices(IServiceCollection services)//Baðýmlýlýk ekleme ve uygulama boyunca eklenecek hizmetleri kullanmak için eklenen metod.
       

        {
            
            services.AddControllersWithViews();//MVC framework ve razor sayfalarýnýn gerektirdiði paylaþýmlý nesnelerin kullanýmý için kullanýlýr
            services.AddDbContext<MiniDukkanContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:MiniDukkanConnection"]));

            services.AddScoped<IDukkanRepository,   EfDukkanRepository>();
        }






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();// Uygulamalarda meydana gelen istisnalarýn ayrýntýlarýný görüntüler. Yazýlým geliþtirme aþamasýnda çok avantajlýdýr. Canlýya alýnmýþ projelerde asla kullanýlmamal9ý.
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }




            app.UseStaticFiles();// Bu metod wwwroot klasörünün içeriðinin kullanýlmasýna olanak saðlar bu olmazsa ora çalýþmaz.

            app.UseRouting();



            app.UseStatusCodePages();// HTTP yanýtlarýna basit mesajlar eklemek için kullanýlýr. Örneðin 404 sayfasý bulunamayan bir sayfadýr ya buna mesaj eklemeize imkan sunar.
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("katsayfa", "{kategori}/Sayfa{urunSayfa:int}", new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("sayfa" , "Sayfa{urunSayfa:int}", new { Controller ="Home", action = "Index",urunSayfa=1 });

                endpoints.MapControllerRoute("kategoria", "{kategori}", new { Controller = "Home", action = "Index", urunSaya = 1 });

                endpoints.MapControllerRoute("sayfalama", "Urunler/Sayfa{urunSayfa}", new { Controller = "Home", action = "Index" , urunSayfa =1});
                endpoints.MapDefaultControllerRoute();  

                //route sayesinde hem gelen istekleri iþlerken hem de giden url oluþturuyoruz.


            });
            
            Hamveri.VeriDoldur(app);


        }



    }
}

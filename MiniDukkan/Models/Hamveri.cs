using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace MiniDukkan.Models
{
    public static class Hamveri
    {

        public static void VeriDoldur(IApplicationBuilder app)
        {



            MiniDukkanContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MiniDukkanContext>();



            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();// Veri tabanına hazır hale getiriyor bu komut ile
            }


            if (!context.Urunler.Any())
            {


                context.Urunler.AddRange

              (

                new Urun
                {
                    UrunAd = " Çıngırak",
                    Aciklama = " Boncuklu Bebek Çıngırağı",
                    Kategori = "Bebek",
                    Fiyat = 15
                },

                new Urun
                {
                    UrunAd = "Oyun Halısı",
                    Aciklama = "Orlon Desenli Oyun Halısı",
                    Kategori = "Bebek",
                    Fiyat = 90
                },

                new Urun
                {
                    UrunAd = "Barbies Bebek",
                    Aciklama = "Pembe Kıyafetli Bebek Oyuncağı",
                    Kategori = "Kız",
                    Fiyat = 55
                },



                new Urun
                {
                    UrunAd = "Mutfak Seti",
                    Aciklama = "Ahşap Tasarım Bebek Oyuncağı",
                    Kategori = "Kız",
                    Fiyat = 250
                },


                new Urun
                {
                    UrunAd = "Kumandalı Araba",
                    Aciklama = "Uzaktan Kumandalı Bebek Oyuncağı",
                    Kategori = "Erkek",
                    Fiyat = 60
                },


                new Urun
                {
                    UrunAd = "PupG Oyun Seti",
                    Aciklama = "PupG Oyun Seti Lisanslı",
                    Kategori = "Erkek",
                    Fiyat = 800
                },


                new Urun
                {
                    UrunAd = "Akülü Jip",
                    Aciklama = "Akülü Volvo",
                    Kategori = "Genel",
                    Fiyat = 6666
                },

                new Urun
                {
                    UrunAd = "Futbol Topu",
                    Aciklama = "Yumuşak Doku Futboll Topu",
                    Kategori = "Erkek",
                    Fiyat = 20
                });
                context.SaveChanges();// Değişiklikleri kayıt ediyoruz.


            }


        }



    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniDukkan.Models;
using MiniDukkan.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDukkan.Controllers
{
    public class HomeController : Controller
    {
        private IDukkanRepository repository;
        public int SayfaBoyutu = 3;
        public HomeController(IDukkanRepository repo)
        {
            repository = repo;
        }






        public ViewResult Index(string kategori, int urunSayfa = 1)
         => View(new UrunlerListesiViewModel { Urunler = repository.Urunler.Where(u => kategori == null || u.Kategori == kategori).
             OrderBy(u => u.UrunID).Skip((urunSayfa - 1) * SayfaBoyutu).Take(SayfaBoyutu), SayfalamaBilgi = new SayfalamaBilgi { GuncelSayfa = urunSayfa, SayfaBasiGosterilecekUrun = SayfaBoyutu, ToplamUrunSayısı = kategori == null ? repository.Urunler.Count() :
           repository.Urunler.Where(e => e.Kategori == kategori
           ).Count() },
         GuncelKategori=kategori});




       



    }
}

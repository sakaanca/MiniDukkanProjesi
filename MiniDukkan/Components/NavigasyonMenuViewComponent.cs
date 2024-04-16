using Microsoft.AspNetCore.Mvc;
using MiniDukkan.Models;
using System.Linq;

namespace MiniDukkan.Companents
{
    public class NavigasyonMenuViewComponent : ViewComponent
    {
        //public string Invoke() //Invoke ile mesajın tarayıcıya gönderilen html sayfasına çağırma işlemni yaptık
        // {
        //    return "Merhaban ben navigasyon";
        //}
        public IDukkanRepository repository;
        public NavigasyonMenuViewComponent(IDukkanRepository repo)
        {
           repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SecilenKategori = RouteData?.Values["kategori"];

            return View(repository.Urunler.Select(x => x.Kategori).Distinct().OrderBy(x => x));
        }
    }
}

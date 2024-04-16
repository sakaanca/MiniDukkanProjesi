using System;
using System.Security.Principal;

namespace MiniDukkan.Models.ViewModels
{
    public class SayfalamaBilgi
    {
        public int ToplamUrunSayısı { get; set; }
        public int SayfaBasiGosterilecekUrun { get; set; }
        public int GuncelSayfa { get; set; }
        public int ToplamSayfalar => (int)Math.Ceiling((decimal)ToplamUrunSayısı / SayfaBasiGosterilecekUrun); 
    }
}

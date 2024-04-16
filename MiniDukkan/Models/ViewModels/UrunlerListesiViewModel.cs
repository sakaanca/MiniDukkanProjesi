using System.Collections;
using System.Collections.Generic;

namespace MiniDukkan.Models.ViewModels
{
    public class UrunlerListesiViewModel
    {
        public IEnumerable<Urun> Urunler { get; set; }
        public SayfalamaBilgi SayfalamaBilgi { get; set; }
        public string GuncelKategori { get; set; }
    }
}

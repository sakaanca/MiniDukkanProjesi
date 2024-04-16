using System.ComponentModel.DataAnnotations.Schema;

namespace MiniDukkan.Models
{
    public class Urun
    {
        public long UrunID   { get; set; }
        public string UrunAd { get; set; }
        public string Aciklama { get; set; }

        [Column(TypeName ="decimal(6,2)")]//Attiribute kullanıyoruz. Başta 6 karakter olsun virgülden sonra da 2 karakter olsun diyoruz. Attirbute ile girilecek verinin tipinin spesifik olmasını istiyoruz.
        public decimal Fiyat { get; set; }
        public string Kategori { get; set; }
    }
}

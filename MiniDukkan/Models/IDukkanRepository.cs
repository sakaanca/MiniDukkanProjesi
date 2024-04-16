using System.Linq;

namespace MiniDukkan.Models
{
    public interface IDukkanRepository
    {
        IQueryable<Urun> Urunler { get; }//Burada bir dizi urun nesnesi elde edebilmek için IqUERYABLE kullandık . Bu IQueryable aslında filtreleme yapar mesela datada ki sadece ürün nesnesini getirir
    }
}

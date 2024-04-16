using System.Linq;

namespace MiniDukkan.Models
{
    public class EfDukkanRepository : IDukkanRepository
    {
        private MiniDukkanContext context;
        public EfDukkanRepository(MiniDukkanContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Urun> Urunler => context.Urunler;
    }
}

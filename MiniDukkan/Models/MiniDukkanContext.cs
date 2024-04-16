using Microsoft.EntityFrameworkCore;

namespace MiniDukkan.Models;

public class MiniDukkanContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=MiniDukkanDb;TrustServerCertificate=true;");
    }
    public MiniDukkanContext(DbContextOptions<MiniDukkanContext>options): base(options)
    {

    }
    public DbSet<Urun> Urunler { get; set; }
}

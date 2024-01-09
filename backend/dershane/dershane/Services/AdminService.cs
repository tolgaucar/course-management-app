// Services/IAdminService.cs
using dershane.Data;
using dershane.Models;
using System.Linq;


namespace dershane.Services
{

    public interface IAdminService
    {
        bool GirisKontrol(Admin admin);
        Admin GetAdminByKullaniciAdi(string kullaniciAdi);
    }

// Services/AdminService.cs




    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool GirisKontrol(Admin admin)
        {
            // Veritabanından tüm adminleri çek
            var admins = _context.Admins.ToList();

            // Giriş kontrolü
            return admins.Any(a => a.KullaniciAdi == admin.KullaniciAdi && a.Sifre == admin.Sifre);
        }

        public Admin GetAdminByKullaniciAdi(string kullaniciAdi)
        {
            // Kullanıcı adına göre admini getir
            return _context.Admins.FirstOrDefault(a => a.KullaniciAdi == kullaniciAdi);
        }
    }
}

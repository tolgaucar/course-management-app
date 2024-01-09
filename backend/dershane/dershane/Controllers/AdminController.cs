// Controllers/AdminController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using dershane.Services;
using dershane.Models;

public class AdminController : Controller
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public IActionResult Index()
    {
        return View();
    }

[HttpPost]
public IActionResult GirisYap(Admin admin)
{
    // Giriş kontrolü
    if (_adminService.GirisKontrol(admin))
    {
        // Yetkili kullanıcıyı session'a ekle
        HttpContext.Session.SetString("KullaniciAdi", admin.KullaniciAdi);
        return Json(new { success = true });
    }

    // Hatalı giriş durumu
    return Json(new { success = false });
}


    public IActionResult Dashboard()
    {
        // Yetkili giriş kontrolü
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index");
        }

        // Dashboard sayfası
        return View();
    }

    public IActionResult CikisYap()
    {
        // Session'dan çıkış
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}

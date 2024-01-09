// Controllers/SinavController.cs
using System.Linq;
using dershane.Models;
using dershane.Services;
using Microsoft.AspNetCore.Mvc;

public class SinavController : Controller
{
    private readonly ISinavService _sinavService;

    public SinavController(ISinavService sinavService)
    {
        _sinavService = sinavService;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        var sinavler = _sinavService.GetSinavler();
        return View(sinavler);
    }

    [HttpPost]
    public IActionResult AddSinav(Sinav sinav)
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        _sinavService.AddSinav(sinav);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult UpdateSinav(int Id)
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        var sinav = _sinavService.GetSinavById(Id);
        return View("Edit", sinav);
    }

    [HttpPost]
    public IActionResult EditSinav(Sinav sinav)
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        _sinavService.UpdateSinav(sinav);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteSinav(int id)
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        _sinavService.DeleteSinav(id);
        return RedirectToAction("Index");
    }
}

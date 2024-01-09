// Controllers/OgretmenController.cs
using System.Linq;
using dershane.Models;
using dershane.Services;
using Microsoft.AspNetCore.Mvc;

public class OgretmenController : Controller
{
    private readonly IOgretmenService _ogretmenService;

    public OgretmenController(IOgretmenService ogretmenService)
    {
        _ogretmenService = ogretmenService;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        var ogretmenler = _ogretmenService.GetOgretmenler();
        return View(ogretmenler);
    }

    [HttpPost]
    public IActionResult AddOgretmen(Ogretmen ogretmen)
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        _ogretmenService.AddOgretmen(ogretmen);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult UpdateOgretmen(int id)
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        var ogretmen = _ogretmenService.GetOgretmenById(id);
        return View("Edit", ogretmen);
    }

    [HttpPost]
    public IActionResult EditOgretmen(Ogretmen ogretmen)
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        _ogretmenService.UpdateOgretmen(ogretmen);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteOgretmen(int id)
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        _ogretmenService.DeleteOgretmen(id);
        return RedirectToAction("Index");
    }
}

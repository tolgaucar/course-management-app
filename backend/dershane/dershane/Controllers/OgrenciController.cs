// Controllers/OgrenciController.cs
using System.Linq;
using dershane.Models;
using dershane.Services;
using Microsoft.AspNetCore.Mvc;

public class OgrenciController : Controller
{
    private readonly IOgrenciService _ogrenciService;

    public OgrenciController(IOgrenciService ogrenciService)
    {
        _ogrenciService = ogrenciService;
    }

    public IActionResult Index()
    {
        var ogrenciler = _ogrenciService.GetOgrenciler();
        return View(ogrenciler);
    }

    [HttpPost]
    public IActionResult AddOgrenci(Ogrenci ogrenci)
    {
        _ogrenciService.AddOgrenci(ogrenci);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult UpdateOgrenci(int id)
    {
        var ogrenci = _ogrenciService.GetOgrenciById(id);
        return View("Edit", ogrenci);
    }

    [HttpPost]
    public IActionResult EditOgrenci(Ogrenci ogrenci)
    {
        _ogrenciService.UpdateOgrenci(ogrenci);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteOgrenci(int id)
    {
        _ogrenciService.DeleteOgrenci(id);
        return RedirectToAction("Index");
    }
}

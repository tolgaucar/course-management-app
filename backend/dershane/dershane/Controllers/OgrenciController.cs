﻿// Controllers/OgrenciController.cs
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
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        var ogrenciler = _ogrenciService.GetOgrenciler();
        return View(ogrenciler);
    }

    [HttpGet]
    public IActionResult GetAllOgrenciler()
    {
        // Tüm öğrencileri veritabanından çek
        List<Ogrenci> ogrenciler = _ogrenciService.GetOgrenciler();

        return Json(ogrenciler);
    }

    [HttpPost]
    public IActionResult AddOgrenci(Ogrenci ogrenci)
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        _ogrenciService.AddOgrenci(ogrenci);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult UpdateOgrenci(int id)
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        var ogrenci = _ogrenciService.GetOgrenciById(id);
        return View("Edit", ogrenci);
    }

    [HttpPost]
    public IActionResult EditOgrenci(Ogrenci ogrenci)
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        _ogrenciService.UpdateOgrenci(ogrenci);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteOgrenci(int id)
    {
        if (HttpContext.Session.GetString("KullaniciAdi") == null)
        {
            return RedirectToAction("Index", "Admin");
        }

        _ogrenciService.DeleteOgrenci(id);
        return RedirectToAction("Index");
    }
}

// Controllers/OgretmenController.cs
using System.Linq;
using dershane.Models;
using dershane.Services;
using Microsoft.AspNetCore.Mvc;

public class FinansalController : Controller
{

    private readonly IFinansalService _finansalService;



    public FinansalController(IFinansalService finansalService)
    {
        _finansalService = finansalService;
    }

    public IActionResult Index()
    {
        var finansallar = _finansalService.GetFinansalIslemler();
        return View(finansallar);
    }

    [HttpPost]
    public IActionResult AddFinansalIslem(Finansal finansal)
    {
        if (ModelState.IsValid)
        {
            _finansalService.AddFinansalIslem(finansal);
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteFinansalIslem(int id)
    {
        _finansalService.DeleteFinansalIslem(id);
        return RedirectToAction("Index");
    }
}

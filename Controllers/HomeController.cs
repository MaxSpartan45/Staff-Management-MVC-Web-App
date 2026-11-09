using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EHA_Assessment.Models;

namespace EHA_Assessment.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // return RedirectToAction("Login", "Access");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

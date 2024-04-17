using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class HomeController : Controller
{

    private readonly Mycontext _context;
    public HomeController(Mycontext context)
    {
       _context = context;
    }

    public IActionResult Index()
    {
        var x = new User("saed","111");
        _context.Users.Add(x);

        _context.SaveChanges();
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

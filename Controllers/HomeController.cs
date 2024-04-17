using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        var allusers = _context.Users.ToList();

        return View(allusers);
    }
    public IActionResult AllBooks()
    {

        var Allbooks = _context.Books.ToList();

        return View(Allbooks);
    }
    public IActionResult OneUserBooks()
    {




        /////////var userId = "your_user_id"; // شناسه کاربر مورد نظر را اینجا قرار دهید

        var OneUserBooks = _context.BookShelfAndUsers
            .Where(x => x.UserId == 1) // فیلتر کردن بر اساس شناسه کاربر
            .Include(x => x.BookShelf) // اضافه کردن اطلاعات قفسه
                .ThenInclude(x => x.BookShelfAndBooks) // اضافه کردن اطلاعات کتاب‌های موجود در قفسه
                    .ThenInclude(x => x.Books) // اضافه کردن اطلاعات کتاب
            .ToList();


        return View(OneUserBooks);
    }

    public IActionResult Privacy()
    {
        // var x = new User("ali","545");
        // _context.Add(x);
        // _context.SaveChanges();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

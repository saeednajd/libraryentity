using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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

        List<OneUserBooksView> users = [.._context.Users
        .Include(x=>x.bookShelfAndUsers)
        .ThenInclude(x=>x.BookShelf)
        .ThenInclude(x=>x.BookShelfAndBooks)
        .ThenInclude(x=>x.Books)
        .Where(x=>x.Id==1)
        .Select(x => new OneUserBooksView{
            Id = x.Id,
            UserName = x.Username,
            Title = x.bookShelfAndUsers.SelectMany(x => x.BookShelf.BookShelfAndBooks).Select(x => x.Books.Title).ToArray()
        })];
        return View(users);
    }
    public IActionResult Status()
    {
        int myuser = 1;
    //// first method
        var userss = _context.Books
    .Where(book => book.BookShelfAndBooks
        .Any(bsb => bsb.BookShelves
            .bookShelfAndUsers
            .Any(bs => bs.User.Id == myuser)))
                .ToList();

        /// secend method
        var users = _context.Books
    .Include(x => x.BookShelfAndBooks)
        .ThenInclude(x => x.BookShelves)
            .ThenInclude(x => x.bookShelfAndUsers)
                .ThenInclude(x => x.User)
    .Where(x => x.BookShelfAndBooks.Any(bsb => bsb.BookShelves.bookShelfAndUsers.Any(x => x.UserId == myuser)))
    .ToList();

        return View(users);
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

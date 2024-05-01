using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using mvc.Models;
using mvc.Models.MyClasse;

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
        //     var userss = _context.Books
        // .Where(book => book.BookShelfAndBooks
        //     .Any(bsb => bsb.BookShelves
        //         .bookShelfAndUsers
        //         .Any(bs => bs.User.Id == myuser)))
        //             .ToList();

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


    public IActionResult Bestbooks()
    {
        var bestBooks = _context.BookShelves
     .Include(x => x.BookShelfAndBooks)
     .ThenInclude(x => x.Books)
     .SelectMany(x => x.BookShelfAndBooks.Select(x => x.Books))
     .GroupBy(x => x.Title)
     .Select(x => new BestBookViewModel { Title = x.Key, Count = x.Count() })
     .OrderByDescending(x => x.Count)
     .Take(5)
     .ToList();

        return View(bestBooks);


    }
    public IActionResult Oneuserfinishedbooks()
    {
        var users = _context.BookShelves
        .Include(x => x.bookShelfAndUsers)
        .ThenInclude(x => x.User)
        .SelectMany(x => x.bookShelfAndUsers.Select(x => x.User))
        .Where(x => x.bookShelfAndUsers.Any(bsb => bsb.BookShelf.BookStatus == 1))
        .GroupBy(x => x.Username)

        .Select(x => new Oneuserfinishedbooksviewmodel
        {
            Username = x.Key,
            Count = x.Count()

        })
        .ToList();
        return View(users);
    }
    public IActionResult oneusershelves()
    {

        

        ////////
        int userId = 1;
        var userdata = _context.Users
           .Where(u => u.Id == userId)
           .SelectMany(u => u.bookShelfAndUsers
            .SelectMany(bsu => bsu.BookShelf.BookShelfAndShelves
            .Select(bsas => new Oneusershelves{
                Name = bsu.User.Username,
                Shelfname = bsas.Shelf.Name
            })))
            .Distinct()
           .ToList();
        return View(userdata);
    }

    public IActionResult BestBookShelvesByUser()
{
    var bestBookShelvesByUser = _context.BookShelves
       .Include(x => x.bookShelfAndUsers)
       .ThenInclude(x => x.User)
       .Include(x => x.BookShelfAndBooks)
       .ThenInclude(x => x.Books)
       .SelectMany(x => x.bookShelfAndUsers.Select(x => new
        {
            User = x.User,
            BookShelf = x.BookShelf,
            Books = x.BookShelf.BookShelfAndBooks.Select(x => x.Books)
        }))
       .GroupBy(x => x.User)
       .Select(x => new
        {
            User = x.Key,
            BookCount = x.Sum(y => y.Books.Count())
        })
       .OrderByDescending(x => x.BookCount)
       .ToList();

    return View(bestBookShelvesByUser);
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

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BibleVerse.Models;
using BibleVerse.Services;

namespace BibleVerse.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
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



    /// <summary>
    /// Process search controller
    /// </summary>
    /// <param name="searchModel"></param>
    /// <returns>IActionResult (Resulst View)_</returns>
    public IActionResult ProcessSearch(SearchModel searchModel)
    {
        // use the security DAO:
        SecurityService dao = new SecurityService();
        List<VerseModel> verses = new List<VerseModel>();

        // Search by new testament, old testament, or both:
        if(searchModel.Testament == "new")
        {
            verses = dao.getNewTestament(searchModel.SearchTerm);
        }
        else if(searchModel.Testament == "old")
        {
            verses = dao.getOldTestament(searchModel.SearchTerm);
        }
        else if(searchModel.Testament == "both")
        {
            verses = dao.getBoth(searchModel.SearchTerm);
        }

        return View("Results", verses);
    }




}


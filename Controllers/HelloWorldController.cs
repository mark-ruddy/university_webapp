using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace university.Controllers;

public class HelloWorldController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public IActionResult Welcome(string name)
    {
        ViewData["Message"] = "Hello" + name;
        return View();
    }
}

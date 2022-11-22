using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace university.Controllers;

public class AboutController : Controller
{
    // GET: /About/
    public IActionResult Index()
    {
        return View();
    }
}

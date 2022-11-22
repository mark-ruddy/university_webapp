using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace university.Controllers;

public class ContactController : Controller
{
    // GET: /Contact/
    public IActionResult Index()
    {
        return View();
    }
}

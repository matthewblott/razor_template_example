using Microsoft.AspNetCore.Mvc;

namespace razor_template_example.web.controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

  }
    
}

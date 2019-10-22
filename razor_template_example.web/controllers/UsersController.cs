using Microsoft.AspNetCore.Mvc;
using razor_template_example.web.models;

namespace razor_template_example.web.controllers
{
  public class UsersController : Controller
  {
    public IActionResult Index()
    {
      var userViewModel = new UserViewModel();

      return View(userViewModel);
    }

    [HttpPost]
    public IActionResult Create()
    {
      return RedirectToAction(nameof(Index));
    }

//    public IActionResult MyView()
//    {
//      return View("~/views/MyView.cshtml");
//    }
    
  }
  
}
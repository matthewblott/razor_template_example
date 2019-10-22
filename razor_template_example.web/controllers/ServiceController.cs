using Microsoft.AspNetCore.Mvc;
using razor_template_example.services;

namespace razor_template_example.web.controllers
{
  public class ServiceController : Controller
  {
    private readonly ITemplateService _templateService;

    public ServiceController(ITemplateService templateService)
    {
      _templateService = templateService;
    }

    public string Example1()
    {
      var retVal = _templateService.Welcome("Hello World!");

      return retVal;

    }
    
    public string Example2()
    {
      var retVal = _templateService.Welcome2("Hello World!");

      return retVal;

    }

  }
  
}
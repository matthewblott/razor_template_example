using System;
using razor_template_example.services;
using razor_template_example.services.models;

namespace razor_template_example.services
{
  public class TemplateService : ITemplateService
  {
    private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

    public TemplateService(IRazorViewToStringRenderer razorViewToStringRenderer) =>
      _razorViewToStringRenderer = razorViewToStringRenderer;

    public string Welcome(string message) =>
      _razorViewToStringRenderer.RenderViewToStringAsync("/views/reports/Welcome.cshtml", new WelcomeViewModel(message))
        .Result;

  }
  
}
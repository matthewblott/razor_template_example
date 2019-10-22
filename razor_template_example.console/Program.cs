using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using razor_template_example.services;
using razor_template_example.web;

namespace razor_template_example.console
{ 
  internal class Program
  {
    private static void Main(string[] args)
    {
      var host = new HostEnvironment();
      var services = new ServiceCollection();
      
      services.AddSingleton<IWebHostEnvironment, HostEnvironment>();
      services.AddSingleton<ILoggerFactory, LoggerFactory>();
      
      var diagnosticSource = new DiagnosticListener("Microsoft.AspNetCore");
      services.AddSingleton<DiagnosticSource>(diagnosticSource);
      
      var startup = new Startup(host);

      startup.ConfigureServices(services);

      var serviceProvider = services.BuildServiceProvider();
      var service = serviceProvider.GetService<ITemplateService>();

      var result = service.Welcome("Hello World!");

      Console.WriteLine(result);

    }
    
  }
  
}

using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using razor_template_example.services;
using Westwind.AspNetCore.Markdown;
//[assembly: AspMvcViewLocationFormat(@"~/../razor_template_example.services/views")]

namespace razor_template_example.web
{
  public class Startup
  {
    public IWebHostEnvironment WebHostEnvironment { get; }
    public Startup(IWebHostEnvironment environment)
    {
      WebHostEnvironment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddScoped<ITemplateService, TemplateService>();
      services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();

      services.AddMarkdown(config =>
      {
        config.AddMarkdownProcessingFolder("/docs/", "~/Views/Shared/__MarkdownPageTemplate.cshtml");
      });
      services.AddRouting(x => x.LowercaseUrls = true);
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddRazorRuntimeCompilation();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();
      app.UseDefaultFiles(new DefaultFilesOptions()
      {
        DefaultFileNames = new List<string> {"index.md", "index.html", "Index.cshtml"}
      });
      app.UseMarkdown();
      app.UseStaticFiles();
      app.UseRouting();
      app.UseCors();
      app.UseEndpoints(endpoints =>
        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"));
        
    }

    public static void Main(string[] args)
    {
      try
      {
        WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build().Run();
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        Console.Read();
      }
      
    }
    
  }
  
}

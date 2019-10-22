using System.Threading.Tasks;

namespace RazorHtmlEmails.RazorClassLib
{
  public interface IRazorViewToStringRenderer
  {
    Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
  }
}
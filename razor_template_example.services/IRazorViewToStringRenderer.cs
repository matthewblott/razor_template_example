using System.Threading.Tasks;

namespace razor_template_example.services
{
  public interface IRazorViewToStringRenderer
  {
    Task<string> RenderViewToStringAsync<TModel>(string viewPath, TModel model);
  }
}
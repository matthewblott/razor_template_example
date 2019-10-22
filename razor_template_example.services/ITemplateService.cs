using System.Threading.Tasks;

namespace razor_template_example.services
{
  public interface ITemplateService
  {
    string Welcome(string message);
    string Welcome2(string message);
  }
}
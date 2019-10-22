namespace RazorHtmlEmails.RazorClassLib.models
{
  public class WelcomeViewModel
  {
    public WelcomeViewModel(string message)
    {
      Message = message;
    }

    public string Message { get; set; }
  }
}
namespace RazorHtmlEmails.RazorClassLib.models
{
  public class AccountViewModel
  {
    public AccountViewModel(string url)
    {
      Url = url;
    }

    public string Url { get; set; }
  }
}
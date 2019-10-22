using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using RazorHtmlEmails.RazorClassLib.Services;
using RazorHtmlEmails.RazorClassLib.Views.Emails.ConfirmAccount;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorHtmlEmails.Common
{
  public class RegisterAccountService : IRegisterAccountService
  {
    private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

    public RegisterAccountService(IRazorViewToStringRenderer razorViewToStringRenderer)
    {
      _razorViewToStringRenderer = razorViewToStringRenderer;
    }

    public async Task<string> Register(string email, string baseUrl)
    {
      var confirmAccountModel = new ConfirmAccountEmailViewModel($"{baseUrl}/{Guid.NewGuid()}");

      var body =
        await _razorViewToStringRenderer.RenderViewToStringAsync(
          "/Views/Emails/ConfirmAccount/ConfirmAccountEmail.cshtml", confirmAccountModel);

      return body;

  }

  public interface IRegisterAccountService
  {
    Task<string> Register(string email, string baseUrl);
  }
  
}
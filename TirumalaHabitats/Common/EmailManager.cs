using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TirumalaHabitats.Models;

namespace TirumalaHabitats.Common
{
  public static class EmailManager
  {
    public static void SendEmail(ContactUsModel model)
    {
      var apiKey = Environment.GetEnvironmentVariable("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");
      var client = new SendGridClient(apiKey);
      var from = new EmailAddress("shivmuk@gmail.com", "Trimula Habitats");
      var subject = "Enquiry Request";
      var to = new EmailAddress("shivmuk@gmail.com", model.Name);
      var plainTextContent = "From: " + model.Name + "Email Id:" + model.EmailId + "Message:" + model.Message;
      var htmlContent = "<strong>From: </strong>" + model.Name + "<br><strong>Email Id:</strong>" + model.EmailId + "<br><strong>Message:</strong>" + model.Message;
      var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
      client.SendEmailAsync(msg);
    }

    public static void SendEmailThroughGoogle(ContactUsModel model)
    {
      var fromAddress = new MailAddress("shivmuk@gmail.com", "Trinula Habitats");
      var toAddress = new MailAddress(model.EmailId, model.Name);
      const string fromPassword = "sin@gh123";
      const string subject = "Enquiry Request for Trimula Property";
      string body = model.Message;

      var smtp = new SmtpClient
      {
        Host = "smtp.gmail.com",
        Port = 587,
        EnableSsl = true,
        //DeliveryMethod = SmtpDeliveryMethod.Network,
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
      };
      using (var message = new MailMessage(fromAddress, toAddress)
      {
        Subject = subject,
        Body = body
      })
      {
        smtp.Send(message);
      }
    }
  }
}
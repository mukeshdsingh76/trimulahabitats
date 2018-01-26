using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TirumalaHabitats.Models
{
  public class ContactUsModel
  {
    [Required(ErrorMessage = "Name is Required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is Required")]
    [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
    public string EmailId { get; set; }

    public string Message { get; set; }
    public string ResponseStatus { get; set; }
  }
}
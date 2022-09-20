using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_01.Models
{
    public class LoginModel
    {
        [EmailAddress(ErrorMessage = "Invalid EmailId")]
        //[Required(ErrorMessage = "EmailId  is required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVC_01.Models
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Enter UserId")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter LastName")]
        public string LastName { get; set; }


        [EmailAddress(ErrorMessage = "Invalid EmailId")]
        //[DataType(DataType.EmailAddress)]
        //[Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [RegularExpression("[0-9a-z]{6,8}",ErrorMessage ="Invalid Password format")]
        public string Password { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is Required.")]
        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm Password: ")]
        [Compare("Password", ErrorMessage = "Password Mismatch")]
        public string ConfirmPassword { get; set; }


        public DateTime CreatedOn { get; set; }

        public string SuccessMessage { get; set; }
    }
}
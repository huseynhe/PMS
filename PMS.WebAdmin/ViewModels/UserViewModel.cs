using PMS.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.WebAdmin.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı ismi gereklidir")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Display(Name = "Tel No:")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email adresi gereklidir")]
        [Display(Name = "Email Adresiniz")]
        [EmailAddress(ErrorMessage = "Email adresiniz doğru formatta değil")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifreniz gereklidir")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Display(Name = "Doğum tarihi")]
        [DataType(DataType.Date)]
        public DateTime? BirthDay { get; set; }
        public string? Picture { get; set; }
        [Display(Name = "Şehir")]
        public string? City { get; set; }
        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }
    }
}

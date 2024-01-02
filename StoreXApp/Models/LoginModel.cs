using System.ComponentModel.DataAnnotations;

namespace StoreXApp.Models
{
    public class LoginModel
    {

        private string? _returnurl;
        public string ReturnUrl
        {
            get
            {
                if (_returnurl is null)
                    return "/";
                else
                    return _returnurl;
            }
            set
            {
                _returnurl = value;
            }
        }

        [Required(ErrorMessage ="Name is Required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
     
    }

}

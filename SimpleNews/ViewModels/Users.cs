using System.ComponentModel.DataAnnotations;

namespace SimpleNews.ViewModels
{
    public class Login
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
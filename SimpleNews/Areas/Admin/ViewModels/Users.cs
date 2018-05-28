using SimpleNews.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleNews.Areas.Admin.ViewModels
{
    public class UsersIndex
    {
        public IEnumerable<User> Users { get; set; }
    }

    public class UsersNew
    {
        [Required, MaxLength(128)]
        public string UserName { get; set; }

        [Required, MaxLength(128)]
        public string Surname { get; set; }

        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required, MaxLength(128), DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
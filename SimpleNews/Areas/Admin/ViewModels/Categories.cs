using SimpleNews.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleNews.Areas.Admin.ViewModels
{
    public class CategoriesIndex
    {
        public IEnumerable<Category> Categories { get; set; }
    }

    public class CategoriesNew
    {
        [Required,MaxLength(128)]
        public string CategoryName { get; set; }
    }
}
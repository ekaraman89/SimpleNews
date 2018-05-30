using SimpleNews.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SimpleNews.Areas.Admin.ViewModels
{
    public class NewsIndex
    {
        public IEnumerable<News> News { get; set; }
    }

    public class NewsNew
    {
        [Required, MaxLength(128)]
        public string Title { get; set; }

        [Required, MaxLength(128)]
        public string Summary { get; set; }

        [Required]
        public string Body { get; set; }

        [Required, MaxLength(128)]
        public string SeoLink { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public IEnumerable<Category> Categories { get { return Database.Session.Query<Category>().ToList(); } }


    }
}
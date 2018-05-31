using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleNews.Models
{
    public class News
    {
        public virtual int ID { get; set; }
        public virtual string Title { get; set; }
        public virtual string Summary { get; set; }
        public virtual string Body { get; set; }
        public virtual string SeoLink { get; set; }
        public virtual string CoverPhoto { get; set; }
        public virtual int CategoryID { get; set; }

        public virtual Category Category { get { return Database.Session.Get<Category>(CategoryID); } set { } }

        public News()
        {
            Category = new Category();
        }
    }

    public class NewsMap : ClassMapping<News>
    {
        public NewsMap()
        {
            Table("News");
            Id(x => x.ID, x => x.Generator(Generators.Identity));
            Property(x => x.Title, x => x.NotNullable(true));
            Property(x => x.Summary, x => x.NotNullable(true));
            Property(x => x.Body, x => x.NotNullable(true));
            Property(x => x.SeoLink, x => x.NotNullable(true));
            Property(x => x.CoverPhoto, x => x.NotNullable(true));
            Property(x => x.CategoryID, x => x.NotNullable(true));
        }
    }
}

using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleNews.Models
{
    public class Category
    {
        public virtual int ID { get; set; }
        public virtual string CategoryName { get; set; }
    }

    public class CategoryMap : ClassMapping<Category>
    {
        public CategoryMap()
        {
            Table("Category");
            Id(x => x.ID, x => x.Generator(Generators.Identity));
            Property(x => x.CategoryName, x => x.NotNullable(true));
        }
    }
}
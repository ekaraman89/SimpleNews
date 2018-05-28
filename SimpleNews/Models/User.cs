using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleNews.Models
{
    public class User
    {
        public virtual int ID { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Password { get; set; }
    }

    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.ID, x => x.Generator(Generators.Identity));
            Property(x=>x.UserName, x => x.NotNullable(true));
            Property(x=>x.Surname, x => x.NotNullable(true));
            Property(x=>x.Mail, x => x.NotNullable(true));
            Property(x=>x.Password, x => x.NotNullable(true));

        }
    }
}
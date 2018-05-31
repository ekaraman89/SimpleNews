using FluentMigrator;

namespace SimpleNews.Migrations
{
    [Migration(1)]
    public class _001_Users_And_Category_And_News : Migration
    {
        public override void Down()
        {
            Delete.Table("News");
            Delete.Table("Category");
            Delete.Table("Users");
        }

        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("Username").AsString(128)
                .WithColumn("Surname").AsString(128)
                .WithColumn("Mail").AsString(256)
                .WithColumn("Password").AsString(128);

            Create.Table("Category")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("CategoryName").AsString(128);

            Create.Table("News")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("Title").AsString(128)
                .WithColumn("Summary").AsString(128)
                .WithColumn("Body").AsString(int.MaxValue)
                .WithColumn("SeoLink").AsString(128)
                .WithColumn("CoverPhoto").AsString(128)
                .WithColumn("CategoryID").AsInt32().ForeignKey("Category","ID");
        }
    }
}
using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(2)]
public class CreateUserTable : Migration
{
    public override void Up()
    {
        Create.Table("users")
            .WithColumn("id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("email").AsString(300).NotNullable()
            .WithColumn("username").AsString(200).NotNullable()
            .WithColumn("password").AsString(1000).NotNullable()
            .WithColumn("createdAt").AsDateTime2().WithDefaultValue(DateTime.UtcNow)
            .WithColumn("updatedAt").AsDateTime2().Nullable()
            .WithColumn("deletedAt").AsDateTime2().Nullable()
            .WithColumn("roleId").AsInt32().ForeignKey("roles", "id");
    }

    public override void Down()
    {
        Delete.Table("users");
    }
}
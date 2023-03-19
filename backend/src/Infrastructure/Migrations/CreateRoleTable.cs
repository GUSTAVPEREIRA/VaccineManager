using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(1)]
public class CreateRoleTable : Migration
{
    public override void Up()
    {
        Create.Table("roles")
            .WithColumn("id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("name").AsString(size: 256).NotNullable()
            .WithColumn("createdAt").AsDateTime().WithDefaultValue(DateTime.UtcNow)
            .WithColumn("deletedAt").AsDateTime().Nullable();
    }

    public override void Down()
    {
        Delete.Table("roles");
    }
}
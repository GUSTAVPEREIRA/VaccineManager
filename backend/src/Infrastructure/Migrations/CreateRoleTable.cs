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
            .WithColumn("value").AsString().NotNullable()
            .WithColumn("enabled").AsBoolean().WithDefaultValue(false);
    }

    public override void Down()
    {
        Delete.Table("roles");
    }
}
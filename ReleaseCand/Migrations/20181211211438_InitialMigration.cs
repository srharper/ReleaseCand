using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReleaseCand.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnOrd",
                columns: table => new
                {
                    OnOrdID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CheeseBurger = table.Column<bool>(nullable: false),
                    Lasagna = table.Column<bool>(nullable: false),
                    TiriMisu = table.Column<bool>(nullable: false),
                    CheeseCake = table.Column<bool>(nullable: false),
                    FrenchFries = table.Column<bool>(nullable: false),
                    Pepsi = table.Column<bool>(nullable: false),
                    Sprite = table.Column<bool>(nullable: false),
                    Water = table.Column<bool>(nullable: false),
                    BillAddress = table.Column<string>(nullable: true),
                    BillCity = table.Column<string>(nullable: true),
                    BillState = table.Column<string>(nullable: true),
                    BillZip = table.Column<string>(nullable: true),
                    CreditCardNum = table.Column<string>(nullable: true),
                    CCV = table.Column<string>(nullable: true),
                    ExpDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnOrd", x => x.OnOrdID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnOrd");
        }
    }
}

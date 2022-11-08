using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroesDB.Migrations
{
    public partial class addListOfCharactersToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IHero",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserControllerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IHero", x => x.id);
                    table.ForeignKey(
                        name: "FK_IHero_Users_UserControllerId",
                        column: x => x.UserControllerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IHero_UserControllerId",
                table: "IHero",
                column: "UserControllerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IHero");
        }
    }
}

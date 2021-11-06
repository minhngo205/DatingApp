using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Database.Migrations
{
    public partial class Userlike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLikes",
                columns: table => new
                {
                    srcUserID = table.Column<int>(type: "int", nullable: false),
                    likedUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikes", x => new { x.likedUserID, x.srcUserID });
                    table.ForeignKey(
                        name: "FK_UserLikes_User_likedUserID",
                        column: x => x.likedUserID,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserLikes_User_srcUserID",
                        column: x => x.srcUserID,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_srcUserID",
                table: "UserLikes",
                column: "srcUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLikes");
        }
    }
}

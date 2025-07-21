using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolioEce.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminProfiles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CvFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminProfiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdminProfiles_AdminUsers_AdminUserID",
                        column: x => x.AdminUserID,
                        principalTable: "AdminUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminProfiles_AdminUserID",
                table: "AdminProfiles",
                column: "AdminUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminProfiles");
        }
    }
}

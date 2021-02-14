using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_DAL.Migrations
{
    public partial class addingRoletabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "SupportUsers");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "SupportUsers",
                newName: "RoleId");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupportUsers_RoleId",
                table: "SupportUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportUsers_Roles_RoleId",
                table: "SupportUsers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportUsers_Roles_RoleId",
                table: "SupportUsers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_SupportUsers_RoleId",
                table: "SupportUsers");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "SupportUsers",
                newName: "Level");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "SupportUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

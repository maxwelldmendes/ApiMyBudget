using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMyBudget.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupOfAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupDescription = table.Column<string>(type: "TEXT", nullable: false),
                    GroupInformation = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOfAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubGroupOfAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubGroupDescription = table.Column<string>(type: "TEXT", nullable: false),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGroupOfAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGroupOfAccounts_GroupOfAccounts_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GroupOfAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassesOfAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassCode = table.Column<string>(type: "TEXT", nullable: false),
                    ClassDescription = table.Column<string>(type: "TEXT", nullable: false),
                    SubGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesOfAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassesOfAccount_SubGroupOfAccounts_SubGroupId",
                        column: x => x.SubGroupId,
                        principalTable: "SubGroupOfAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassesOfAccount_SubGroupId",
                table: "ClassesOfAccount",
                column: "SubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubGroupOfAccounts_GroupId",
                table: "SubGroupOfAccounts",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassesOfAccount");

            migrationBuilder.DropTable(
                name: "SubGroupOfAccounts");

            migrationBuilder.DropTable(
                name: "GroupOfAccounts");
        }
    }
}

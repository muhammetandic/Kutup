using Microsoft.EntityFrameworkCore.Migrations;

namespace Kutup.Data.Migrations
{
    public partial class yeni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataImports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DataImportType = table.Column<int>(type: "INTEGER", nullable: false),
                    IsSystemImport = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nodes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataImports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataImportHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataImportId = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    RowCount = table.Column<int>(type: "INTEGER", nullable: false),
                    SuccessfulCount = table.Column<int>(type: "INTEGER", nullable: false),
                    FailedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ErrorLogs = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataImportHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataImportHistories_DataImports_DataImportId",
                        column: x => x.DataImportId,
                        principalTable: "DataImports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataImportMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataImportId = table.Column<int>(type: "INTEGER", nullable: false),
                    ColumnName = table.Column<string>(type: "TEXT", nullable: true),
                    NodeName = table.Column<string>(type: "TEXT", nullable: true),
                    Formula = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataImportMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataImportMappings_DataImports_DataImportId",
                        column: x => x.DataImportId,
                        principalTable: "DataImports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataImportHistories_DataImportId",
                table: "DataImportHistories",
                column: "DataImportId");

            migrationBuilder.CreateIndex(
                name: "IX_DataImportMappings_DataImportId",
                table: "DataImportMappings",
                column: "DataImportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataImportHistories");

            migrationBuilder.DropTable(
                name: "DataImportMappings");

            migrationBuilder.DropTable(
                name: "DataImports");
        }
    }
}

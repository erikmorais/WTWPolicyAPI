using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WTW.App.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyHolders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyHolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PolicyHolderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyNumber);
                    table.ForeignKey(
                        name: "FK_Policies_PolicyHolders_PolicyHolderId",
                        column: x => x.PolicyHolderId,
                        principalTable: "PolicyHolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PolicyHolders",
                columns: new[] { "Id", "Age", "Gender", "Name" },
                values: new object[] { 1, 44, 0, "Dwayne Johnson" });

            migrationBuilder.InsertData(
                table: "PolicyHolders",
                columns: new[] { "Id", "Age", "Gender", "Name" },
                values: new object[] { 2, 38, 0, "John Cena" });

            migrationBuilder.InsertData(
                table: "PolicyHolders",
                columns: new[] { "Id", "Age", "Gender", "Name" },
                values: new object[] { 3, 42, 1, "Trish Stratus" });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "PolicyNumber", "PolicyHolderId" },
                values: new object[,]
                {
                    { 739562, 1 },
                    { 383002, 1 },
                    { 462946, 2 },
                    { 355679, 3 },
                    { 589881, 3 },
                    { 998256, 3 },
                    { 100374, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policies_PolicyHolderId",
                table: "Policies",
                column: "PolicyHolderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "PolicyHolders");
        }
    }
}

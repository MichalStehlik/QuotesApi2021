using Microsoft.EntityFrameworkCore.Migrations;

namespace QuotesApi2021.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuoteTag",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteTag", x => new { x.QuoteId, x.TagId });
                    table.ForeignKey(
                        name: "FK_QuoteTag_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "<p>Hloupost je největší zlo.</p>" },
                    { 2, "<p>Kde blb, tam nebezpečno!</p>" },
                    { 3, "<p>Jestliže se člověk hádá s blbcem víc, jak půl minuty, hádají se už dva blbci.</p>" },
                    { 4, "<p>Největší životní lekcí je, že i blbci mají někdy pravdu.</p>" },
                    { 5, "<p>If you’re going through hell, keep going.</p>" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Text", "Type" },
                values: new object[,]
                {
                    { 1, "Werich, Jan", 1 },
                    { 2, "Hloupost", 0 },
                    { 3, "cs", 2 },
                    { 4, "Blbec", 0 },
                    { 5, "Churchill, Winston", 1 },
                    { 6, "Peklo", 0 },
                    { 7, "en", 2 },
                    { 8, "Těžkosti", 0 }
                });

            migrationBuilder.InsertData(
                table: "QuoteTag",
                columns: new[] { "QuoteId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 4 },
                    { 4, 5 },
                    { 5, 5 },
                    { 5, 6 },
                    { 5, 7 },
                    { 5, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuoteTag_TagId",
                table: "QuoteTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteTag");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}

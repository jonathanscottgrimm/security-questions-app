using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityQuestionsApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityAnswers",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SecurityQuestionId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityAnswers", x => new { x.PersonId, x.SecurityQuestionId });
                    table.ForeignKey(
                        name: "FK_SecurityAnswers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecurityAnswers_SecurityQuestions_SecurityQuestionId",
                        column: x => x.SecurityQuestionId,
                        principalTable: "SecurityQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SecurityQuestions",
                columns: new[] { "Id", "Question" },
                values: new object[,]
                {
                    { -11, "What is your favorite album?" },
                    { -10, "Who is your favorite actor/actress?" },
                    { -9, "What is your favorite meal?" },
                    { -8, "Where did you meet your spouse?" },
                    { -7, "What was your favorite toy as a child?" },
                    { -6, "What was the make of your first car?" },
                    { -5, "What was the mascot of your high school?" },
                    { -4, "What high school did you attend?" },
                    { -3, "What is your mother's maiden name?" },
                    { -2, "What is the name of your favorite pet?" },
                    { -1, "In what city were you born?" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityAnswers_SecurityQuestionId",
                table: "SecurityAnswers",
                column: "SecurityQuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityAnswers");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "SecurityQuestions");
        }
    }
}

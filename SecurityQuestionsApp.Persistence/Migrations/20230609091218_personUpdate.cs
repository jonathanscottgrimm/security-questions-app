using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecurityQuestionsApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class personUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SecurityAnswers",
                table: "SecurityAnswers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SecurityAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SecurityQuestionId",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecurityAnswers",
                table: "SecurityAnswers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityAnswers_PersonId",
                table: "SecurityAnswers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_SecurityQuestionId",
                table: "People",
                column: "SecurityQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_SecurityQuestions_SecurityQuestionId",
                table: "People",
                column: "SecurityQuestionId",
                principalTable: "SecurityQuestions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_SecurityQuestions_SecurityQuestionId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecurityAnswers",
                table: "SecurityAnswers");

            migrationBuilder.DropIndex(
                name: "IX_SecurityAnswers_PersonId",
                table: "SecurityAnswers");

            migrationBuilder.DropIndex(
                name: "IX_People_SecurityQuestionId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SecurityAnswers");

            migrationBuilder.DropColumn(
                name: "SecurityQuestionId",
                table: "People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecurityAnswers",
                table: "SecurityAnswers",
                columns: new[] { "PersonId", "SecurityQuestionId" });
        }
    }
}

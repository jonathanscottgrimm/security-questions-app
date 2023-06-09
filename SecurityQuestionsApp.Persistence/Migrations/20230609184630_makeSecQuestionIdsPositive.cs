using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityQuestionsApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class makeSecQuestionIdsPositive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "SecurityQuestions",
                columns: new[] { "Id", "Question" },
                values: new object[,]
                {
                    { 1, "In what city were you born?" },
                    { 2, "What is the name of your favorite pet?" },
                    { 3, "What is your mother's maiden name?" },
                    { 4, "What high school did you attend?" },
                    { 5, "What was the mascot of your high school?" },
                    { 6, "What was the make of your first car?" },
                    { 7, "What was your favorite toy as a child?" },
                    { 8, "Where did you meet your spouse?" },
                    { 9, "What is your favorite meal?" },
                    { 10, "Who is your favorite actor/actress?" },
                    { 11, "What is your favorite album?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "Id",
                keyValue: 11);

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
        }
    }
}

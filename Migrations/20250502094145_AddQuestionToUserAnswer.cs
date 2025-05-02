using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTests.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionToUserAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionId",
                table: "UserAsnwers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserAsnwers_QuestionId",
                table: "UserAsnwers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAsnwers_Questions_QuestionId",
                table: "UserAsnwers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAsnwers_Questions_QuestionId",
                table: "UserAsnwers");

            migrationBuilder.DropIndex(
                name: "IX_UserAsnwers_QuestionId",
                table: "UserAsnwers");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "UserAsnwers");
        }
    }
}

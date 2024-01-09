using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dershane.Migrations
{
    /// <inheritdoc />
    public partial class SinavModelGuncelleme5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OgrenciNots_Sinavs_SinavId",
                table: "OgrenciNots");

            migrationBuilder.DropIndex(
                name: "IX_OgrenciNots_SinavId",
                table: "OgrenciNots");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OgrenciNots_SinavId",
                table: "OgrenciNots",
                column: "SinavId");

            migrationBuilder.AddForeignKey(
                name: "FK_OgrenciNots_Sinavs_SinavId",
                table: "OgrenciNots",
                column: "SinavId",
                principalTable: "Sinavs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dershane.Migrations
{
    /// <inheritdoc />
    public partial class SinavModelGuncelleme3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SinavAdi",
                table: "OgrenciNots");

            migrationBuilder.DropColumn(
                name: "SinavTarihi",
                table: "OgrenciNots");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SinavAdi",
                table: "OgrenciNots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SinavTarihi",
                table: "OgrenciNots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

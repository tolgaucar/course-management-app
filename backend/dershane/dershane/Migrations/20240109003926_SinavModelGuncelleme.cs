using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dershane.Migrations
{
    /// <inheritdoc />
    public partial class SinavModelGuncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SınavTarihi",
                table: "OgrenciNots",
                newName: "SinavTarihi");

            migrationBuilder.RenameColumn(
                name: "SınavAdı",
                table: "OgrenciNots",
                newName: "SinavAdi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SinavTarihi",
                table: "OgrenciNots",
                newName: "SınavTarihi");

            migrationBuilder.RenameColumn(
                name: "SinavAdi",
                table: "OgrenciNots",
                newName: "SınavAdı");
        }
    }
}

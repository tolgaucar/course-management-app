using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dershane.Migrations
{
    /// <inheritdoc />
    public partial class OgrenciModelGuncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OgrenciNo",
                table: "Ogrencis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OgrenciNo",
                table: "Ogrencis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

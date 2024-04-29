using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webbanxe.Data.migrations
{
    /// <inheritdoc />
    public partial class modifi_cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Accessaries_IdAccessary",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Bike_IdBike",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_IdAccessary",
                table: "Carts");

            migrationBuilder.AlterColumn<long>(
                name: "IdBike",
                table: "Carts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "IdAccessary",
                table: "Carts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_IdAccessary",
                table: "Carts",
                column: "IdAccessary",
                unique: true,
                filter: "[IdAccessary] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Accessaries_IdAccessary",
                table: "Carts",
                column: "IdAccessary",
                principalTable: "Accessaries",
                principalColumn: "IdAccessary");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Bike_IdBike",
                table: "Carts",
                column: "IdBike",
                principalTable: "Bike",
                principalColumn: "IdBike");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Accessaries_IdAccessary",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Bike_IdBike",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_IdAccessary",
                table: "Carts");

            migrationBuilder.AlterColumn<long>(
                name: "IdBike",
                table: "Carts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IdAccessary",
                table: "Carts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_IdAccessary",
                table: "Carts",
                column: "IdAccessary",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Accessaries_IdAccessary",
                table: "Carts",
                column: "IdAccessary",
                principalTable: "Accessaries",
                principalColumn: "IdAccessary",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Bike_IdBike",
                table: "Carts",
                column: "IdBike",
                principalTable: "Bike",
                principalColumn: "IdBike",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

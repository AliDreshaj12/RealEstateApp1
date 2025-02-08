using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApp.Migrations
{
    /// <inheritdoc />
    public partial class NenProna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    PronaID = table.Column<int>(type: "int", nullable: false),
                    floor = table.Column<int>(type: "int", nullable: false),
                    nrDhomave = table.Column<int>(type: "int", nullable: false),
                    kaAnshensor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.PronaID);
                    table.ForeignKey(
                        name: "FK_Apartments_Pronas_PronaID",
                        column: x => x.PronaID,
                        principalTable: "Pronas",
                        principalColumn: "PronaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shtepiat",
                columns: table => new
                {
                    PronaID = table.Column<int>(type: "int", nullable: false),
                    size = table.Column<double>(type: "float", nullable: false),
                    nrFloors = table.Column<int>(type: "int", nullable: false),
                    kaGarazhd = table.Column<bool>(type: "bit", nullable: false),
                    kaPool = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shtepiat", x => x.PronaID);
                    table.ForeignKey(
                        name: "FK_Shtepiat_Pronas_PronaID",
                        column: x => x.PronaID,
                        principalTable: "Pronas",
                        principalColumn: "PronaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tokat",
                columns: table => new
                {
                    PronaID = table.Column<int>(type: "int", nullable: false),
                    LandType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Zona = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TopografiaTokes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WaterSource = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokat", x => x.PronaID);
                    table.ForeignKey(
                        name: "FK_Tokat_Pronas_PronaID",
                        column: x => x.PronaID,
                        principalTable: "Pronas",
                        principalColumn: "PronaID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Shtepiat");

            migrationBuilder.DropTable(
                name: "Tokat");
        }
    }
}

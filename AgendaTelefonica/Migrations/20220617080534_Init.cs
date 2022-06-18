using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaTelefonica.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    IdAgenda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAgenda = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.IdAgenda);
                });

            migrationBuilder.CreateTable(
                name: "CompaniaTelefonica",
                columns: table => new
                {
                    IdCompania = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompania = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniaTelefonica", x => x.IdCompania);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    idContacto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAgenda = table.Column<int>(nullable: true),
                    NombreCompleto = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    IdTelefono = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.idContacto);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    idDireccion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idContacto = table.Column<int>(nullable: true),
                    Calle = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    AlturaCalle = table.Column<int>(nullable: false),
                    CodigoPostal = table.Column<int>(nullable: false),
                    Localidad = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Provincia = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.idDireccion);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    idEmail = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorreoElectronico = table.Column<string>(unicode: false, maxLength: 75, nullable: false),
                    IdContacto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.idEmail);
                });

            migrationBuilder.CreateTable(
                name: "Telefono",
                columns: table => new
                {
                    idTelefono = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idContacto = table.Column<int>(nullable: true),
                    IdCompania = table.Column<int>(nullable: true),
                    CodigoArea = table.Column<int>(nullable: false),
                    Prefijo = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefono", x => x.idTelefono);
                });

            migrationBuilder.Sql("SET IDENTITY_INSERT Agenda ON");
            migrationBuilder.Sql("INSERT INTO Agenda (IdAgenda, NombreAgenda) VALUES (1, 'Agenda #1')");
            migrationBuilder.Sql("SET IDENTITY_INSERT Agenda OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "CompaniaTelefonica");

            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Telefono");
        }
    }
}

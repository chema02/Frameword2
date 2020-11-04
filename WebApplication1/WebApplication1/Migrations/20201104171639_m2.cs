using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoId", "Equipolocal", "Equipovisitante" },
                values: new object[,]
                {
                    { 1, "catarrocha", "masanasa" },
                    { 2, "ceuta", "melilla" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Apellido", "Edad", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, "sinmiedo", 44, "jose@es", "juan" },
                    { 2, "algrande", 55, "juan@melones", "pepico" }
                });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "CuentaId", "NombreBanco", "NumeroCuenta", "Saldo", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "bancojones", 1234567890, 1000, 1 },
                    { 2, "bancodelparke", 554466112, 5000, 2 }
                });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "MercadoId", "Cuota_Over", "Cuota_Under", "Dinero_Over", "Dinero_Under", "EventoId", "Over_Under" },
                values: new object[,]
                {
                    { 1, 2.5f, 3.5f, 1000, 2000, 1, 1.5f },
                    { 2, 1.5f, 2.5f, 5000, 10000, 2, 2.5f }
                });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "Cuota", "Dinero_Apostado", "MercadoId", "Tipo", "UsuarioId" },
                values: new object[] { 1, 1f, 1000, 1, "over", 1 });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "Cuota", "Dinero_Apostado", "MercadoId", "Tipo", "UsuarioId" },
                values: new object[] { 2, 1.5f, 555, 2, "under", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "MercadoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "MercadoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "EventoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "EventoId",
                keyValue: 2);
        }
    }
}

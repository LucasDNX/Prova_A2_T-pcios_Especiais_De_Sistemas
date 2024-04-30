using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Joao.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                });

            migrationBuilder.CreateTable(
                name: "Folhas",
                columns: table => new
                {
                    FolhaId = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<float>(type: "REAL", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    Mes = table.Column<int>(type: "INTEGER", nullable: false),
                    SalarioBruto = table.Column<float>(type: "REAL", nullable: true),
                    ImpostoIRRF = table.Column<float>(type: "REAL", nullable: true),
                    ImpostoINSS = table.Column<float>(type: "REAL", nullable: true),
                    ImpostoFGTS = table.Column<float>(type: "REAL", nullable: true),
                    SalarioLiquido = table.Column<float>(type: "REAL", nullable: true),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.FolhaId);
                    table.ForeignKey(
                        name: "FK_Folhas_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folhas_FuncionarioId",
                table: "Folhas",
                column: "FuncionarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folhas");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}

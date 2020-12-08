using Microsoft.EntityFrameworkCore.Migrations;

namespace adm_csharp.Migrations
{
    public partial class csharp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbConfiguracao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaminhoBaseDocumento = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ImagemPadrao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UnidadeImgBD = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CaminhoImgBD = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbConfiguracao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbFormulario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Form = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFormulario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbGrupoPessoa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grupo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbGrupoPessoa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbOpcao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbOpcao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbUsuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupoPessoaID = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Maquina = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUsuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbUsuario_tbGrupoPessoa_GrupoPessoaID",
                        column: x => x.GrupoPessoaID,
                        principalTable: "tbGrupoPessoa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbPermissaoTela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormularioId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Leitura = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Incluir = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Alterar = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Excluir = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPermissaoTela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbPermissaoTela_tbFormulario_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "tbFormulario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbPermissaoTela_tbUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbUsuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbPermissaoTela_FormularioId",
                table: "tbPermissaoTela",
                column: "FormularioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbPermissaoTela_UsuarioId",
                table: "tbPermissaoTela",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbUsuario_GrupoPessoaID",
                table: "tbUsuario",
                column: "GrupoPessoaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbConfiguracao");

            migrationBuilder.DropTable(
                name: "tbOpcao");

            migrationBuilder.DropTable(
                name: "tbPermissaoTela");

            migrationBuilder.DropTable(
                name: "tbFormulario");

            migrationBuilder.DropTable(
                name: "tbUsuario");

            migrationBuilder.DropTable(
                name: "tbGrupoPessoa");
        }
    }
}

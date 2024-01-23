using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroPessoaFisicaBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaocampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_PessoasFisicas_PessoaFisicaId",
                table: "Contato");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_PessoasFisicas_PessoaFisicaId",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contato",
                table: "Contato");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Contato",
                newName: "Contatos");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_PessoaFisicaId",
                table: "Enderecos",
                newName: "IX_Enderecos_PessoaFisicaId");

            migrationBuilder.RenameIndex(
                name: "IX_Contato_PessoaFisicaId",
                table: "Contatos",
                newName: "IX_Contatos_PessoaFisicaId");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaFisicaId",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PessoaFisicaId",
                table: "Contatos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_PessoasFisicas_PessoaFisicaId",
                table: "Contatos",
                column: "PessoaFisicaId",
                principalTable: "PessoasFisicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_PessoasFisicas_PessoaFisicaId",
                table: "Enderecos",
                column: "PessoaFisicaId",
                principalTable: "PessoasFisicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_PessoasFisicas_PessoaFisicaId",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_PessoasFisicas_PessoaFisicaId",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Endereco");

            migrationBuilder.RenameTable(
                name: "Contatos",
                newName: "Contato");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_PessoaFisicaId",
                table: "Endereco",
                newName: "IX_Endereco_PessoaFisicaId");

            migrationBuilder.RenameIndex(
                name: "IX_Contatos_PessoaFisicaId",
                table: "Contato",
                newName: "IX_Contato_PessoaFisicaId");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaFisicaId",
                table: "Endereco",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaFisicaId",
                table: "Contato",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contato",
                table: "Contato",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_PessoasFisicas_PessoaFisicaId",
                table: "Contato",
                column: "PessoaFisicaId",
                principalTable: "PessoasFisicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_PessoasFisicas_PessoaFisicaId",
                table: "Endereco",
                column: "PessoaFisicaId",
                principalTable: "PessoasFisicas",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Criacao = table.Column<DateTime>(nullable: false),
                    Alteracao = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(150)", maxLength: 50, nullable: false),
                    Preco = table.Column<decimal>(type: "money", nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_produtos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_produtos");
        }
    }
}

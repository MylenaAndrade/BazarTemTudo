using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazarTemTudo.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome_cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel_cliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dt_compra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quant_necessaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pedido_id = table.Column<int>(type: "int", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome_produto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quant = table.Column<int>(type: "int", nullable: false),
                    Preco_item = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dt_compra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dt_pagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_pedido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco_total = table.Column<int>(type: "int", nullable: false),
                    Cliente_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quant_total = table.Column<int>(type: "int", nullable: false),
                    Servico_envio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_entrega1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_entrega2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_entrega3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade_entrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado_entrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais_entrega = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Upc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome_produto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "MovimentacaoEstoques");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}

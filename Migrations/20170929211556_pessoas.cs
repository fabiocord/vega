using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vega.Migrations
{
    public partial class pessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Vehicles_VehicleId",
                table: "Photos");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Photos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PessoasFisicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Logradouro = table.Column<string>(maxLength: 200, nullable: true),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    SobreNome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasFisicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoasJuridicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CNPJ = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Logradouro = table.Column<string>(maxLength: 200, nullable: true),
                    NomeFantasia = table.Column<string>(maxLength: 50, nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasJuridicas", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Vehicles_VehicleId",
                table: "Photos",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Vehicles_VehicleId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "PessoasFisicas");

            migrationBuilder.DropTable(
                name: "PessoasJuridicas");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Photos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Vehicles_VehicleId",
                table: "Photos",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

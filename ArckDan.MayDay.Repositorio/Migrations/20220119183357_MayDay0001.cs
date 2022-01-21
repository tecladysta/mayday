﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArckDan.MayDay.Repositorio.Migrations
{
    public partial class MayDay0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_MAYDAY_CAMPO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    NOME_TECNICO = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TIPO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TAMANHO = table.Column<int>(type: "int", nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAYDAY_CAMPO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_MAYDAY_LOGIN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAYDAY_LOGIN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_MAYDAY_PERFIL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAYDAY_PERFIL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_MAYDAY_TOKEN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    SENHA = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAYDAY_TOKEN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_MAYDAY_SENHA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_LOGIN = table.Column<int>(type: "int", nullable: false),
                    CHAVE = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    EXPIRACAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAYDAY_SENHA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_MAYDAY_SENHA_TB_MAYDAY_LOGIN_ID_LOGIN",
                        column: x => x.ID_LOGIN,
                        principalTable: "TB_MAYDAY_LOGIN",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_MAYDAY_CAMPO_PERFIL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_CAMPO = table.Column<int>(type: "int", nullable: false),
                    ID_PERFIL = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAYDAY_CAMPO_PERFIL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_MAYDAY_CAMPO_PERFIL_TB_MAYDAY_CAMPO_ID_CAMPO",
                        column: x => x.ID_CAMPO,
                        principalTable: "TB_MAYDAY_CAMPO",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_MAYDAY_CAMPO_PERFIL_TB_MAYDAY_PERFIL_ID_PERFIL",
                        column: x => x.ID_PERFIL,
                        principalTable: "TB_MAYDAY_PERFIL",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_MAYDAY_USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PERFIL = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false),
                    CPF = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAYDAY_USUARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_MAYDAY_USUARIO_TB_MAYDAY_PERFIL_ID_PERFIL",
                        column: x => x.ID_PERFIL,
                        principalTable: "TB_MAYDAY_PERFIL",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_MAYDAY_ENDERECO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USUARIO = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "char(8)", maxLength: 8, nullable: false),
                    LOGRADOURO = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    NUMERO = table.Column<int>(type: "int", nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    BAIRRO = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    CIDADE = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    UF = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAYDAY_ENDERECO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_MAYDAY_ENDERECO_TB_MAYDAY_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "TB_MAYDAY_USUARIO",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_MAYDAY_CAMPO_PERFIL_ID_CAMPO",
                table: "TB_MAYDAY_CAMPO_PERFIL",
                column: "ID_CAMPO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MAYDAY_CAMPO_PERFIL_ID_PERFIL",
                table: "TB_MAYDAY_CAMPO_PERFIL",
                column: "ID_PERFIL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MAYDAY_ENDERECO_ID_USUARIO",
                table: "TB_MAYDAY_ENDERECO",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MAYDAY_SENHA_ID_LOGIN",
                table: "TB_MAYDAY_SENHA",
                column: "ID_LOGIN");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MAYDAY_USUARIO_ID_PERFIL",
                table: "TB_MAYDAY_USUARIO",
                column: "ID_PERFIL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MAYDAY_CAMPO_PERFIL");

            migrationBuilder.DropTable(
                name: "TB_MAYDAY_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_MAYDAY_SENHA");

            migrationBuilder.DropTable(
                name: "TB_MAYDAY_TOKEN");

            migrationBuilder.DropTable(
                name: "TB_MAYDAY_CAMPO");

            migrationBuilder.DropTable(
                name: "TB_MAYDAY_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_MAYDAY_LOGIN");

            migrationBuilder.DropTable(
                name: "TB_MAYDAY_PERFIL");
        }
    }
}

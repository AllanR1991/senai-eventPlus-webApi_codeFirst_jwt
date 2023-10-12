﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace senai_eventPlus_webApi_codeFirst_jwt.Migrations
{
    /// <inheritdoc />
    public partial class criacaobanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    idInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cnpj = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    endereco = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    razaoSocial = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    nomeFantasia = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.idInstituicao);
                });

            migrationBuilder.CreateTable(
                name: "TiposEvento",
                columns: table => new
                {
                    idTiposEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipoEvento = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEvento", x => x.idTiposEvento);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    idTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipoUsuario = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.idTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    idEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idTipoEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nomeEvento = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    dataEvento = table.Column<DateTime>(type: "DATE", nullable: false),
                    horarioEvento = table.Column<TimeSpan>(type: "TIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.idEvento);
                    table.ForeignKey(
                        name: "FK_Evento_Instituicao_idInstituicao",
                        column: x => x.idInstituicao,
                        principalTable: "Instituicao",
                        principalColumn: "idInstituicao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evento_TiposEvento_idTipoEvento",
                        column: x => x.idTipoEvento,
                        principalTable: "TiposEvento",
                        principalColumn: "idTiposEvento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    senha = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    idTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_idTipoUsuario",
                        column: x => x.idTipoUsuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "idTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    idComentario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    exibe = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.idComentario);
                    table.ForeignKey(
                        name: "FK_Comentario_Evento_idEvento",
                        column: x => x.idEvento,
                        principalTable: "Evento",
                        principalColumn: "idEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentario_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PresencasEvento",
                columns: table => new
                {
                    idPresençasEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    situacao = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresencasEvento", x => x.idPresençasEvento);
                    table.ForeignKey(
                        name: "FK_PresencasEvento_Evento_idEvento",
                        column: x => x.idEvento,
                        principalTable: "Evento",
                        principalColumn: "idEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresencasEvento_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instituicao",
                columns: new[] { "idInstituicao", "cnpj", "endereco", "nomeFantasia", "razaoSocial" },
                values: new object[] { new Guid("dda605c1-21e5-4ed3-ad17-5e36cd4ea199"), "1234567891012", "Rua Niteroi 180", "DevSchool", "Escola Internacional de Desenvolvimento" });

            migrationBuilder.InsertData(
                table: "TipoUsuario",
                columns: new[] { "idTipoUsuario", "tipoUsuario" },
                values: new object[,]
                {
                    { new Guid("7f20d53d-0ed5-4b6a-911e-39752d78277b"), "Administrador" },
                    { new Guid("940d502d-d177-42ac-b88c-ef0d7b607a39"), "Comum" }
                });

            migrationBuilder.InsertData(
                table: "TiposEvento",
                columns: new[] { "idTiposEvento", "tipoEvento" },
                values: new object[,]
                {
                    { new Guid("1bfbf44b-c4ae-4a57-bfb7-1babb590a6bc"), "C#" },
                    { new Guid("9b650c6e-ee33-4c64-bd79-840e8e745da8"), "SQL Server" }
                });

            migrationBuilder.InsertData(
                table: "Evento",
                columns: new[] { "idEvento", "dataEvento", "descricao", "horarioEvento", "idInstituicao", "idTipoEvento", "nomeEvento" },
                values: new object[] { new Guid("ff0ce50c-4e32-4a03-8b88-dc19cee152fb"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conceitos básicos do SQL Server, como DDL, DML, DQL.", new TimeSpan(0, 13, 0, 0, 0), new Guid("dda605c1-21e5-4ed3-ad17-5e36cd4ea199"), new Guid("9b650c6e-ee33-4c64-bd79-840e8e745da8"), "Introdução ao banco de dados SQL Server" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "idUsuario", "email", "idTipoUsuario", "nome", "senha" },
                values: new object[,]
                {
                    { new Guid("173fe1bf-ec4a-4ccf-9d54-be7c4f7e5614"), "allan@allan.com", new Guid("7f20d53d-0ed5-4b6a-911e-39752d78277b"), "Allan Rodrigues", "allan" },
                    { new Guid("31fad950-d604-4c04-be9d-4d5f59731fdd"), "everton@everton.com", new Guid("940d502d-d177-42ac-b88c-ef0d7b607a39"), "Everton Araujo", "everton" }
                });

            migrationBuilder.InsertData(
                table: "Comentario",
                columns: new[] { "idComentario", "descricao", "exibe", "idEvento", "idUsuario" },
                values: new object[] { new Guid("41b5e224-cdd1-48fd-905d-b86fd2e25f7d"), "Excelente evento", true, new Guid("ff0ce50c-4e32-4a03-8b88-dc19cee152fb"), new Guid("31fad950-d604-4c04-be9d-4d5f59731fdd") });

            migrationBuilder.InsertData(
                table: "PresencasEvento",
                columns: new[] { "idPresençasEvento", "idEvento", "idUsuario", "situacao" },
                values: new object[] { new Guid("29b61829-49af-4205-975e-a60f37baca5b"), new Guid("ff0ce50c-4e32-4a03-8b88-dc19cee152fb"), new Guid("31fad950-d604-4c04-be9d-4d5f59731fdd"), true });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_idEvento",
                table: "Comentario",
                column: "idEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_idUsuario",
                table: "Comentario",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_idInstituicao",
                table: "Evento",
                column: "idInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_idTipoEvento",
                table: "Evento",
                column: "idTipoEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicao_cnpj",
                table: "Instituicao",
                column: "cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PresencasEvento_idEvento",
                table: "PresencasEvento",
                column: "idEvento");

            migrationBuilder.CreateIndex(
                name: "IX_PresencasEvento_idUsuario",
                table: "PresencasEvento",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TiposEvento_tipoEvento",
                table: "TiposEvento",
                column: "tipoEvento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoUsuario_tipoUsuario",
                table: "TipoUsuario",
                column: "tipoUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_email",
                table: "Usuario",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idTipoUsuario",
                table: "Usuario",
                column: "idTipoUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "PresencasEvento");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "TiposEvento");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
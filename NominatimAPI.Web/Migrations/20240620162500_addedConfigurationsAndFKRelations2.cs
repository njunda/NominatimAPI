using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NominatimAPI.Web.Migrations
{
    /// <inheritdoc />
    public partial class addedConfigurationsAndFKRelations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QueryResponseEntityModel_ResponseEntityModel_ResponseEntity~",
                table: "QueryResponseEntityModel");

            migrationBuilder.DropForeignKey(
                name: "FK_QuerySearchModels_QueryResponseEntityModel_QueryResponseEnt~",
                table: "QuerySearchModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponseEntityModel_QuerySearchModels_QuerySearchModelId",
                table: "ResponseEntityModel");

            migrationBuilder.DropIndex(
                name: "IX_QuerySearchModels_QueryResponseEntityModelId",
                table: "QuerySearchModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseEntityModel",
                table: "ResponseEntityModel");

            migrationBuilder.DropIndex(
                name: "IX_ResponseEntityModel_QuerySearchModelId",
                table: "ResponseEntityModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QueryResponseEntityModel",
                table: "QueryResponseEntityModel");

            migrationBuilder.DropColumn(
                name: "QueryResponseEntityModelId",
                table: "QuerySearchModels");

            migrationBuilder.RenameTable(
                name: "ResponseEntityModel",
                newName: "ResponseEntityModels");

            migrationBuilder.RenameTable(
                name: "QueryResponseEntityModel",
                newName: "QueryResponseEntityModels");

            migrationBuilder.RenameIndex(
                name: "IX_QueryResponseEntityModel_ResponseEntityModelId",
                table: "QueryResponseEntityModels",
                newName: "IX_QueryResponseEntityModels_ResponseEntityModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseEntityModels",
                table: "ResponseEntityModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QueryResponseEntityModels",
                table: "QueryResponseEntityModels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseEntityModels_QuerySearchModelId",
                table: "ResponseEntityModels",
                column: "QuerySearchModelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QueryResponseEntityModels_ResponseEntityModels_ResponseEnti~",
                table: "QueryResponseEntityModels",
                column: "ResponseEntityModelId",
                principalTable: "ResponseEntityModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseEntityModels_QuerySearchModels_QuerySearchModelId",
                table: "ResponseEntityModels",
                column: "QuerySearchModelId",
                principalTable: "QuerySearchModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QueryResponseEntityModels_ResponseEntityModels_ResponseEnti~",
                table: "QueryResponseEntityModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponseEntityModels_QuerySearchModels_QuerySearchModelId",
                table: "ResponseEntityModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseEntityModels",
                table: "ResponseEntityModels");

            migrationBuilder.DropIndex(
                name: "IX_ResponseEntityModels_QuerySearchModelId",
                table: "ResponseEntityModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QueryResponseEntityModels",
                table: "QueryResponseEntityModels");

            migrationBuilder.RenameTable(
                name: "ResponseEntityModels",
                newName: "ResponseEntityModel");

            migrationBuilder.RenameTable(
                name: "QueryResponseEntityModels",
                newName: "QueryResponseEntityModel");

            migrationBuilder.RenameIndex(
                name: "IX_QueryResponseEntityModels_ResponseEntityModelId",
                table: "QueryResponseEntityModel",
                newName: "IX_QueryResponseEntityModel_ResponseEntityModelId");

            migrationBuilder.AddColumn<Guid>(
                name: "QueryResponseEntityModelId",
                table: "QuerySearchModels",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseEntityModel",
                table: "ResponseEntityModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QueryResponseEntityModel",
                table: "QueryResponseEntityModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_QuerySearchModels_QueryResponseEntityModelId",
                table: "QuerySearchModels",
                column: "QueryResponseEntityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseEntityModel_QuerySearchModelId",
                table: "ResponseEntityModel",
                column: "QuerySearchModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_QueryResponseEntityModel_ResponseEntityModel_ResponseEntity~",
                table: "QueryResponseEntityModel",
                column: "ResponseEntityModelId",
                principalTable: "ResponseEntityModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuerySearchModels_QueryResponseEntityModel_QueryResponseEnt~",
                table: "QuerySearchModels",
                column: "QueryResponseEntityModelId",
                principalTable: "QueryResponseEntityModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseEntityModel_QuerySearchModels_QuerySearchModelId",
                table: "ResponseEntityModel",
                column: "QuerySearchModelId",
                principalTable: "QuerySearchModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

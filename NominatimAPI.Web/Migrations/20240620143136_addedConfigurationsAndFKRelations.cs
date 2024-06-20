using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NominatimAPI.Web.Migrations
{
    /// <inheritdoc />
    public partial class addedConfigurationsAndFKRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "QueryResponseEntityModelId",
                table: "QuerySearchModels",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ResponseEntityModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    QuerySearchModelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseEntityModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseEntityModel_QuerySearchModels_QuerySearchModelId",
                        column: x => x.QuerySearchModelId,
                        principalTable: "QuerySearchModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueryResponseEntityModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlaceId = table.Column<int>(type: "integer", nullable: false),
                    Licence = table.Column<string>(type: "text", nullable: false),
                    OsmType = table.Column<string>(type: "text", nullable: false),
                    OsmId = table.Column<long>(type: "bigint", nullable: false),
                    Lat = table.Column<string>(type: "text", nullable: false),
                    Lon = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    PlaceRank = table.Column<int>(type: "integer", nullable: false),
                    Importance = table.Column<double>(type: "double precision", nullable: false),
                    Addresstype = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    Boundingbox = table.Column<List<string>>(type: "text[]", nullable: false),
                    ResponseEntityModelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryResponseEntityModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueryResponseEntityModel_ResponseEntityModel_ResponseEntity~",
                        column: x => x.ResponseEntityModelId,
                        principalTable: "ResponseEntityModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuerySearchModels_QueryResponseEntityModelId",
                table: "QuerySearchModels",
                column: "QueryResponseEntityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_QueryResponseEntityModel_ResponseEntityModelId",
                table: "QueryResponseEntityModel",
                column: "ResponseEntityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseEntityModel_QuerySearchModelId",
                table: "ResponseEntityModel",
                column: "QuerySearchModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuerySearchModels_QueryResponseEntityModel_QueryResponseEnt~",
                table: "QuerySearchModels",
                column: "QueryResponseEntityModelId",
                principalTable: "QueryResponseEntityModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuerySearchModels_QueryResponseEntityModel_QueryResponseEnt~",
                table: "QuerySearchModels");

            migrationBuilder.DropTable(
                name: "QueryResponseEntityModel");

            migrationBuilder.DropTable(
                name: "ResponseEntityModel");

            migrationBuilder.DropIndex(
                name: "IX_QuerySearchModels_QueryResponseEntityModelId",
                table: "QuerySearchModels");

            migrationBuilder.DropColumn(
                name: "QueryResponseEntityModelId",
                table: "QuerySearchModels");
        }
    }
}

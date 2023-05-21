using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Airport_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "air_companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    id_city = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_air_companies", x => x.id);
                    table.ForeignKey(
                        name: "FK_air_companies_cities_id_city",
                        column: x => x.id_city,
                        principalTable: "cities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "flights",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_city_from = table.Column<int>(type: "integer", nullable: true),
                    id_city_to = table.Column<int>(type: "integer", nullable: true),
                    departure_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    arrive_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    id_airline = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flights", x => x.id);
                    table.ForeignKey(
                        name: "FK_flights_air_companies_id_airline",
                        column: x => x.id_airline,
                        principalTable: "air_companies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_flights_cities_id_city_from",
                        column: x => x.id_city_from,
                        principalTable: "cities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_flights_cities_id_city_to",
                        column: x => x.id_city_to,
                        principalTable: "cities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    passport = table.Column<string>(type: "text", nullable: false),
                    luggage_weight = table.Column<float>(type: "real", nullable: false),
                    hand_luggage_weight = table.Column<float>(type: "real", nullable: false),
                    id_flight = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengers", x => x.id);
                    table.ForeignKey(
                        name: "FK_passengers_flights_id_flight",
                        column: x => x.id_flight,
                        principalTable: "flights",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_air_companies_id_city",
                table: "air_companies",
                column: "id_city");

            migrationBuilder.CreateIndex(
                name: "IX_flights_id_airline",
                table: "flights",
                column: "id_airline");

            migrationBuilder.CreateIndex(
                name: "IX_flights_id_city_from",
                table: "flights",
                column: "id_city_from");

            migrationBuilder.CreateIndex(
                name: "IX_flights_id_city_to",
                table: "flights",
                column: "id_city_to");

            migrationBuilder.CreateIndex(
                name: "IX_passengers_id_flight",
                table: "passengers",
                column: "id_flight");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passengers");

            migrationBuilder.DropTable(
                name: "flights");

            migrationBuilder.DropTable(
                name: "air_companies");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}

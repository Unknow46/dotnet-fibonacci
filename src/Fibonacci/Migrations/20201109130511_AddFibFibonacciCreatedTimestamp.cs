using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fibonacci.Migrations
{
    public partial class AddFibFibonacciCreatedTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sch_fib");

            migrationBuilder.CreateTable(
                name: "TFibonacci",
                schema: "sch_fib",
                columns: table => new
                {
                    FIB_Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    FIB_Input = table.Column<int>(nullable: false),
                    FIB_Output = table.Column<long>(nullable: false),
                    FIB_TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PKFibonacci", x => x.FIB_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TFibonacci",
                schema: "sch_fib");
        }
    }
}

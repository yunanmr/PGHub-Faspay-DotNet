using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PGHub.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    key = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    prefix = table.Column<string>(type: "text", nullable: true),
                    merchant_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    trx_id = table.Column<string>(type: "text", nullable: false),
                    va_number = table.Column<string>(type: "text", nullable: true),
                    bill_no = table.Column<string>(type: "text", nullable: true),
                    bill_date = table.Column<string>(type: "text", nullable: true),
                    bill_expired = table.Column<string>(type: "text", nullable: true),
                    bill_desc = table.Column<string>(type: "text", nullable: true),
                    bill_currency = table.Column<string>(type: "text", nullable: true),
                    bill_total = table.Column<string>(type: "text", nullable: true),
                    cust_no = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    cust_name = table.Column<string>(type: "text", nullable: true),
                    msisdn = table.Column<string>(type: "text", nullable: true),
                    pay_type = table.Column<string>(type: "text", nullable: true),
                    payment_channel = table.Column<string>(type: "text", nullable: true),
                    terminal = table.Column<string>(type: "text", nullable: true),
                    payment_reff = table.Column<string>(type: "text", nullable: true),
                    payment_date = table.Column<string>(type: "text", nullable: true),
                    payment_total = table.Column<string>(type: "text", nullable: true),
                    payment_status_desc = table.Column<string>(type: "text", nullable: true),
                    payment_status_code = table.Column<string>(type: "text", nullable: true),
                    payment_channel_uid = table.Column<string>(type: "text", nullable: true),
                    signature = table.Column<string>(type: "text", nullable: true),
                    merchant_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.trx_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "transactions");
        }
    }
}

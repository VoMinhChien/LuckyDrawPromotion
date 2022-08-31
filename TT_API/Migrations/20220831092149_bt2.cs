using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT_API.Migrations
{
    public partial class bt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Campaign_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campaign_Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Compaihn_Type = table.Column<bool>(type: "bit", nullable: false),
                    AutoUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ApplyForAll = table.Column<bool>(type: "bit", nullable: false),
                    LimitOneCampaignToOneCustomer = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CodeUsageLimit = table.Column<int>(type: "int", nullable: false),
                    Unlimited = table.Column<bool>(type: "bit", nullable: false),
                    CodeCount = table.Column<int>(type: "int", nullable: false),
                    Charset = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CodeLength = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "varchar(50)", nullable: true),
                    Postfix = table.Column<string>(type: "varchar(50)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Campaign_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Users_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    User_Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    DataOfBirth = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Position = table.Column<string>(type: "varchar(255)", nullable: false),
                    TypeOfBusiness = table.Column<string>(type: "varchar(255)", nullable: false),
                    Location = table.Column<string>(type: "varchar(255)", nullable: false),
                    User_Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    User_Password2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    User_Roles = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NumberOfTurns = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Users_Id);
                });

            migrationBuilder.CreateTable(
                name: "BarCodes",
                columns: table => new
                {
                    BarCodes_Id = table.Column<int>(type: "Int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarCodes_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCodes_BarCodes = table.Column<string>(type: "varchar(255)", nullable: true),
                    BarCodes_QRCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    BarCodes_CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    BarCodes_ExpiredDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    BarCodes_ScannedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    BarCodes_Scanned = table.Column<int>(type: "Int", nullable: false),
                    BarCodes_Active = table.Column<bool>(type: "bit", nullable: false),
                    Campaign_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarCodes", x => x.BarCodes_Id);
                    table.ForeignKey(
                        name: "FK_BarCodes_Campaigns_Campaign_Id",
                        column: x => x.Campaign_Id,
                        principalTable: "Campaigns",
                        principalColumn: "Campaign_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Giftss",
                columns: table => new
                {
                    Gifts_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campaign_Id = table.Column<int>(type: "int", nullable: false),
                    Gifts_Product = table.Column<string>(type: "varchar(255)", nullable: false),
                    Gifts_Description = table.Column<string>(type: "varchar(255)", nullable: false),
                    Gifts_CodeCount = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giftss", x => x.Gifts_Id);
                    table.ForeignKey(
                        name: "FK_Giftss_Campaigns_Campaign_Id",
                        column: x => x.Campaign_Id,
                        principalTable: "Campaigns",
                        principalColumn: "Campaign_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarcodeHistorys",
                columns: table => new
                {
                    BarcodeHistory_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarcodeHistory_Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    BarcodeHistory_CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    BarcodeHistory_ScannedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    BarcodeHistory_SpinDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    BarcodeHistory_Owner = table.Column<int>(type: "Int", nullable: false),
                    BarcodeHistory_Scanned = table.Column<int>(type: "Int", nullable: false),
                    BarcodeHistory_UsedForSpin = table.Column<bool>(type: "bit", nullable: false),
                    Barcode_Id = table.Column<int>(type: "Int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarcodeHistorys", x => x.BarcodeHistory_Id);
                    table.ForeignKey(
                        name: "FK_BarcodeHistorys_BarCodes_Barcode_Id",
                        column: x => x.Barcode_Id,
                        principalTable: "BarCodes",
                        principalColumn: "BarCodes_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarcodeHistorys_Users_BarcodeHistory_Owner",
                        column: x => x.BarcodeHistory_Owner,
                        principalTable: "Users",
                        principalColumn: "Users_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ruless",
                columns: table => new
                {
                    Rule_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campaign_Id = table.Column<int>(type: "int", nullable: false),
                    Rules_Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Rules_GiftName = table.Column<int>(type: "int", nullable: false),
                    Rules_Amount = table.Column<int>(type: "int", nullable: false),
                    Rule_StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Rule_EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Rule_AllDay = table.Column<bool>(type: "bit", nullable: false),
                    Rules_Probability = table.Column<int>(type: "int", nullable: false),
                    Rules_RepeatDaily_StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rules_RepeatDaily_EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruless", x => x.Rule_Id);
                    table.ForeignKey(
                        name: "FK_Ruless_Giftss_Rules_GiftName",
                        column: x => x.Rules_GiftName,
                        principalTable: "Giftss",
                        principalColumn: "Gifts_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Winners",
                columns: table => new
                {
                    Winners_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Winners_UserID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Winners_PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Winners_Address = table.Column<string>(type: "varchar(255)", nullable: false),
                    Winners_Windate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Winners_GiftId = table.Column<int>(type: "int", nullable: false),
                    Winners_SentGift = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winners", x => x.Winners_Id);
                    table.ForeignKey(
                        name: "FK_Winners_Giftss_Winners_GiftId",
                        column: x => x.Winners_GiftId,
                        principalTable: "Giftss",
                        principalColumn: "Gifts_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarcodeHistorys_Barcode_Id",
                table: "BarcodeHistorys",
                column: "Barcode_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BarcodeHistorys_BarcodeHistory_Owner",
                table: "BarcodeHistorys",
                column: "BarcodeHistory_Owner");

            migrationBuilder.CreateIndex(
                name: "IX_BarCodes_Campaign_Id",
                table: "BarCodes",
                column: "Campaign_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Giftss_Campaign_Id",
                table: "Giftss",
                column: "Campaign_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ruless_Rules_GiftName",
                table: "Ruless",
                column: "Rules_GiftName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Winners_Winners_GiftId",
                table: "Winners",
                column: "Winners_GiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarcodeHistorys");

            migrationBuilder.DropTable(
                name: "Ruless");

            migrationBuilder.DropTable(
                name: "Winners");

            migrationBuilder.DropTable(
                name: "BarCodes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Giftss");

            migrationBuilder.DropTable(
                name: "Campaigns");
        }
    }
}

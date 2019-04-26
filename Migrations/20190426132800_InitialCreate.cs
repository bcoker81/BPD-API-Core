using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bpd01webapicore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Table = table.Column<string>(maxLength: 20, nullable: true),
                    FK_Id = table.Column<int>(nullable: false),
                    Uri = table.Column<string>(maxLength: 255, nullable: true),
                    UploadDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    FileType = table.Column<string>(maxLength: 255, nullable: true),
                    AddBy = table.Column<string>(maxLength: 100, nullable: false),
                    AddWhen = table.Column<DateTime>(nullable: true),
                    ModBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModWhen = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grants",
                columns: table => new
                {
                    IsNew = table.Column<bool>(nullable: true),
                    Division = table.Column<string>(maxLength: 255, nullable: true),
                    NickName = table.Column<string>(maxLength: 32, nullable: true),
                    FinancialReportDueDate = table.Column<DateTime>(nullable: true),
                    ProgrammingReportDueDate = table.Column<DateTime>(nullable: true),
                    ImportDate = table.Column<DateTime>(nullable: true),
                    RemainingBal = table.Column<decimal>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MshpGrantNumber = table.Column<string>(maxLength: 10, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    GrantName = table.Column<string>(maxLength: 255, nullable: true),
                    CfdaNumber = table.Column<string>(maxLength: 32, nullable: true),
                    Component = table.Column<string>(maxLength: 10, nullable: true),
                    ProjectDirector = table.Column<string>(maxLength: 255, nullable: true),
                    Accountant = table.Column<string>(maxLength: 127, nullable: true),
                    ApplicationAmount = table.Column<double>(nullable: true),
                    ProjectStartDate = table.Column<DateTime>(nullable: true),
                    ProjectEndDate = table.Column<DateTime>(nullable: true),
                    ExtendedProjectDate = table.Column<DateTime>(nullable: true),
                    AwardAmount = table.Column<decimal>(nullable: false),
                    Expenditures = table.Column<decimal>(nullable: false),
                    AwardContractNumber = table.Column<string>(maxLength: 255, nullable: true),
                    Match = table.Column<string>(maxLength: 32, nullable: true),
                    Grantor = table.Column<int>(nullable: false),
                    ApplicationDueDate = table.Column<DateTime>(nullable: true),
                    ApplicationStatus = table.Column<int>(nullable: false),
                    GrantCategory = table.Column<int>(nullable: false),
                    Forecast = table.Column<int>(nullable: false),
                    Adjustments = table.Column<string>(maxLength: 35, nullable: true),
                    AwardDate = table.Column<DateTime>(nullable: true),
                    GrantType = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ModBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PickLists",
                columns: table => new
                {
                    PickListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Index = table.Column<int>(nullable: false),
                    PickList = table.Column<string>(maxLength: 32, nullable: true),
                    Value = table.Column<string>(maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddBy = table.Column<string>(maxLength: 100, nullable: true),
                    AddWhen = table.Column<DateTime>(nullable: false),
                    ModBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModWhen = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickLists", x => x.PickListId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocumentData = table.Column<string>(nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    FK_Attachment_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Attachments_FK_Attachment_Id",
                        column: x => x.FK_Attachment_Id,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Agency = table.Column<int>(nullable: false),
                    ReportingCategory = table.Column<string>(maxLength: 10, nullable: true),
                    CategoryClassification = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Allocation = table.Column<decimal>(nullable: true),
                    Expenses = table.Column<decimal>(nullable: true),
                    Remaining = table.Column<decimal>(nullable: true),
                    Notes = table.Column<string>(maxLength: 2000, nullable: true),
                    AddBy = table.Column<string>(maxLength: 100, nullable: true),
                    AddWhen = table.Column<DateTime>(nullable: true),
                    ModBy = table.Column<string>(maxLength: 100, nullable: true),
                    Division = table.Column<int>(nullable: false),
                    ModWhen = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FK_Grant_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CatId);
                    table.ForeignKey(
                        name: "FK_Categories_Grants_FK_Grant_Id",
                        column: x => x.FK_Grant_Id,
                        principalTable: "Grants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(maxLength: 2000, nullable: true),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    ModWhen = table.Column<DateTime>(nullable: true),
                    ModBy = table.Column<string>(maxLength: 100, nullable: true),
                    AddBy = table.Column<string>(maxLength: 100, nullable: true),
                    FK_Grant_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Grants_FK_Grant_Id",
                        column: x => x.FK_Grant_Id,
                        principalTable: "Grants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Extensions",
                columns: table => new
                {
                    GrantExtensionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExtensionDate = table.Column<DateTime>(nullable: false),
                    ModWhen = table.Column<DateTime>(nullable: true),
                    AddWhen = table.Column<DateTime>(nullable: true),
                    ModBy = table.Column<string>(maxLength: 100, nullable: true),
                    AddBy = table.Column<string>(maxLength: 100, nullable: true),
                    FK_Grant_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extensions", x => x.GrantExtensionId);
                    table.ForeignKey(
                        name: "FK_Extensions_Grants_FK_Grant_Id",
                        column: x => x.FK_Grant_Id,
                        principalTable: "Grants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GANs",
                columns: table => new
                {
                    GANId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GrantAdjustments = table.Column<int>(nullable: false),
                    GANStatus = table.Column<int>(nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionInitials = table.Column<string>(maxLength: 10, nullable: true),
                    GAN_Notes = table.Column<string>(maxLength: 500, nullable: true),
                    FK_Grant_Id = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddWhen = table.Column<DateTime>(nullable: true),
                    AddBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModWhen = table.Column<DateTime>(nullable: true),
                    ModBy = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GANs", x => x.GANId);
                    table.ForeignKey(
                        name: "FK_GANs_Grants_FK_Grant_Id",
                        column: x => x.FK_Grant_Id,
                        principalTable: "Grants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ldpr",
                columns: table => new
                {
                    LdprId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LdprNumber = table.Column<string>(maxLength: 10, nullable: true),
                    FK_Grant_Id = table.Column<int>(nullable: false),
                    AddWhen = table.Column<DateTime>(nullable: true),
                    ModWhen = table.Column<DateTime>(nullable: true),
                    AddBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModBy = table.Column<string>(maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ldpr", x => x.LdprId);
                    table.ForeignKey(
                        name: "FK_Ldpr_Grants_FK_Grant_Id",
                        column: x => x.FK_Grant_Id,
                        principalTable: "Grants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    ReportType = table.Column<string>(maxLength: 1, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    AddBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModBy = table.Column<string>(maxLength: 100, nullable: true),
                    FK_Grant_Id = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FinancialReportingPeriod = table.Column<string>(nullable: true),
                    ProgrammingReportingPeriod = table.Column<string>(nullable: true),
                    DateSubmittedToGrantor = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Grants_FK_Grant_Id",
                        column: x => x.FK_Grant_Id,
                        principalTable: "Grants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenditures",
                columns: table => new
                {
                    ExpenditureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExpenditureDate = table.Column<DateTime>(nullable: true),
                    DocumentNumber = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    Notes = table.Column<string>(maxLength: 2000, nullable: true),
                    DivStatus = table.Column<bool>(nullable: true),
                    BpdDate = table.Column<DateTime>(nullable: true),
                    BpdAmount = table.Column<decimal>(nullable: false),
                    SamDocNumber = table.Column<string>(maxLength: 100, nullable: true),
                    Vendor = table.Column<string>(maxLength: 50, nullable: true),
                    BpdNotes = table.Column<string>(maxLength: 2000, nullable: true),
                    AddBy = table.Column<string>(maxLength: 100, nullable: true),
                    AddWhen = table.Column<DateTime>(nullable: true),
                    ModBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModWhen = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsCredit = table.Column<bool>(nullable: false),
                    FK_Category_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenditures", x => x.ExpenditureId);
                    table.ForeignKey(
                        name: "FK_Expenditures_Categories_FK_Category_Id",
                        column: x => x.FK_Category_Id,
                        principalTable: "Categories",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_FK_Grant_Id",
                table: "Categories",
                column: "FK_Grant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FK_Grant_Id",
                table: "Comments",
                column: "FK_Grant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FK_Attachment_Id",
                table: "Documents",
                column: "FK_Attachment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_FK_Category_Id",
                table: "Expenditures",
                column: "FK_Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Extensions_FK_Grant_Id",
                table: "Extensions",
                column: "FK_Grant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_GANs_FK_Grant_Id",
                table: "GANs",
                column: "FK_Grant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ldpr_FK_Grant_Id",
                table: "Ldpr",
                column: "FK_Grant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_FK_Grant_Id",
                table: "Reports",
                column: "FK_Grant_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Expenditures");

            migrationBuilder.DropTable(
                name: "Extensions");

            migrationBuilder.DropTable(
                name: "GANs");

            migrationBuilder.DropTable(
                name: "Ldpr");

            migrationBuilder.DropTable(
                name: "PickLists");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Grants");
        }
    }
}

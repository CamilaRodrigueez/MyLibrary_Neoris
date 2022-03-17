using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Core.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Library");

            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "Authors",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editorial",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Direction = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeState",
                schema: "Master",
                columns: table => new
                {
                    IdTypeState = table.Column<int>(nullable: false),
                    TypeState = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeState", x => x.IdTypeState);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "Security",
                columns: table => new
                {
                    IdRol = table.Column<int>(nullable: false),
                    Rol = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "TypePermission",
                schema: "Security",
                columns: table => new
                {
                    IdTypePermission = table.Column<int>(nullable: false),
                    TypePermission = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePermission", x => x.IdTypePermission);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Security",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Bocks",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<string>(maxLength: 100, nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    Pages = table.Column<int>(nullable: false),
                    IdEditorial = table.Column<int>(nullable: false),
                    IdTypeState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bocks_Editorial_IdEditorial",
                        column: x => x.IdEditorial,
                        principalSchema: "Library",
                        principalTable: "Editorial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bocks_TypeState_IdTypeState",
                        column: x => x.IdTypeState,
                        principalSchema: "Master",
                        principalTable: "TypeState",
                        principalColumn: "IdTypeState",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "Security",
                columns: table => new
                {
                    IdPermission = table.Column<int>(nullable: false),
                    Permission = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    IdTypePermission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.IdPermission);
                    table.ForeignKey(
                        name: "FK_Permission_TypePermission_IdTypePermission",
                        column: x => x.IdTypePermission,
                        principalSchema: "Security",
                        principalTable: "TypePermission",
                        principalColumn: "IdTypePermission",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUser",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolUser_Rol_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "Security",
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUser_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsBooks",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAuthor = table.Column<int>(nullable: false),
                    IdBooks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorsBooks_Authors_IdAuthor",
                        column: x => x.IdAuthor,
                        principalSchema: "Library",
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorsBooks_Bocks_IdBooks",
                        column: x => x.IdBooks,
                        principalSchema: "Library",
                        principalTable: "Bocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolesPermission",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(nullable: false),
                    IdPermission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesPermission_Permission_IdPermission",
                        column: x => x.IdPermission,
                        principalSchema: "Security",
                        principalTable: "Permission",
                        principalColumn: "IdPermission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesPermission_Rol_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "Security",
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsBooks_IdAuthor",
                schema: "Library",
                table: "AuthorsBooks",
                column: "IdAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsBooks_IdBooks",
                schema: "Library",
                table: "AuthorsBooks",
                column: "IdBooks",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bocks_IdEditorial",
                schema: "Library",
                table: "Bocks",
                column: "IdEditorial");

            migrationBuilder.CreateIndex(
                name: "IX_Bocks_IdTypeState",
                schema: "Library",
                table: "Bocks",
                column: "IdTypeState");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_IdTypePermission",
                schema: "Security",
                table: "Permission",
                column: "IdTypePermission");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermission_IdPermission",
                schema: "Security",
                table: "RolesPermission",
                column: "IdPermission");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermission_IdRol",
                schema: "Security",
                table: "RolesPermission",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_IdRol",
                schema: "Security",
                table: "RolUser",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_IdUser",
                schema: "Security",
                table: "RolUser",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "Security",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorsBooks",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "RolesPermission",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "RolUser",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Authors",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Bocks",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Editorial",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "TypeState",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "TypePermission",
                schema: "Security");
        }
    }
}

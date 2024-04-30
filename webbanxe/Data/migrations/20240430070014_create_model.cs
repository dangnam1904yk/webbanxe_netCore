using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webbanxe.Data.migrations
{
    /// <inheritdoc />
    public partial class create_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessaries",
                columns: table => new
                {
                    IdAccessary = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAccessary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DescriptionAccessary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageAccessary = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PricePromotion = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessaries", x => x.IdAccessary);
                });

            migrationBuilder.CreateTable(
                name: "AdminMenu",
                columns: table => new
                {
                    AdminMenuID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemLevel = table.Column<int>(type: "int", nullable: false),
                    ParentLevel = table.Column<int>(type: "int", nullable: false),
                    ItemOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ItemTarget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMenu", x => x.AdminMenuID);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Levels = table.Column<int>(type: "int", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuOrder = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuID);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    IdNotification = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    img = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.IdNotification);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SloganTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NameImg = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeBike",
                columns: table => new
                {
                    IdType = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameType = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeBike", x => x.IdType);
                });

            migrationBuilder.CreateTable(
                name: "view_Post_Menu",
                columns: table => new
                {
                    PostID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abstract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    PostOrder = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_view_Post_Menu", x => x.PostID);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abstract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PostOrder = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Post_Menu_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menu",
                        principalColumn: "MenuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bike",
                columns: table => new
                {
                    IdBike = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBike = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    PricePromotion = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    ImageBike = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    DescriptionBike = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdType = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bike", x => x.IdBike);
                    table.ForeignKey(
                        name: "FK_Bike_TypeBike_IdType",
                        column: x => x.IdType,
                        principalTable: "TypeBike",
                        principalColumn: "IdType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNotification = table.Column<long>(type: "bigint", nullable: false),
                    IdUser = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notification_IdNotification",
                        column: x => x.IdNotification,
                        principalTable: "Notification",
                        principalColumn: "IdNotification",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    IdCart = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityPurchased = table.Column<long>(type: "bigint", nullable: false),
                    IdBike = table.Column<long>(type: "bigint", nullable: true),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdAccessary = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.IdCart);
                    table.ForeignKey(
                        name: "FK_Carts_Accessaries_IdAccessary",
                        column: x => x.IdAccessary,
                        principalTable: "Accessaries",
                        principalColumn: "IdAccessary");
                    table.ForeignKey(
                        name: "FK_Carts_Bike_IdBike",
                        column: x => x.IdBike,
                        principalTable: "Bike",
                        principalColumn: "IdBike");
                    table.ForeignKey(
                        name: "FK_Carts_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    IdOrder = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberPhone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdCart = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Order_Carts_IdCart",
                        column: x => x.IdCart,
                        principalTable: "Carts",
                        principalColumn: "IdCart",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    IdPayment = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<long>(type: "bigint", nullable: false),
                    IdOrder = table.Column<long>(type: "bigint", nullable: false),
                    maCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maGiaoDich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maMerchant = table.Column<long>(type: "bigint", nullable: false),
                    maVnpTransactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenNganHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tongTien = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserIdUser = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.IdPayment);
                    table.ForeignKey(
                        name: "FK_Payments_Order_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bike_IdType",
                table: "Bike",
                column: "IdType");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_IdAccessary",
                table: "Carts",
                column: "IdAccessary");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_IdBike",
                table: "Carts",
                column: "IdBike");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_IdUser",
                table: "Carts",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdCart",
                table: "Order",
                column: "IdCart");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IdOrder",
                table: "Payments",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserIdUser",
                table: "Payments",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Post_MenuID",
                table: "Post",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_IdNotification",
                table: "UserNotifications",
                column: "IdNotification");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_IdUser",
                table: "UserNotifications",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminMenu");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "view_Post_Menu");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Accessaries");

            migrationBuilder.DropTable(
                name: "Bike");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TypeBike");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

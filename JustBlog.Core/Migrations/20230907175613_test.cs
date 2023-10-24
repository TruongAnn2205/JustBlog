using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustBlog.Core.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1026)", maxLength: 1026, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ShortDescription = table.Column<string>(name: "Short Description", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PostContent = table.Column<string>(name: "Post Content", type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ViewCount = table.Column<int>(name: "View Count", type: "int", nullable: false, defaultValue: 0),
                    RateCount = table.Column<int>(name: "Rate Count", type: "int", nullable: false, defaultValue: 0),
                    TotalRate = table.Column<int>(name: "Total Rate", type: "int", nullable: false, defaultValue: 0),
                    PostedOn = table.Column<DateTime>(name: "Posted On", type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(1026)", maxLength: 1026, nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMaps",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMaps", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "Arcu vel porta sollicitudin adipiscing euismod maecenas bibendum dui elementum fermentum pharetra", "Varius tempor", "volutpat-interdum" },
                    { 2, "Porttitor vel eu bibendum mauris id conubia porta justo nam luctus quam", "Tortor pulvinar", "aliquet-dictumst" },
                    { 3, "Lectus ac eleifend eget quam sagittis vel platea consectetur vivamus non porta", "Et odio", "pulvinar-tristique" },
                    { 4, "Diam ante aptent nulla elit at malesuada finibus aenean euismod pretium vitae", "Ligula laoreet", "porta-nec" },
                    { 5, "Nostra pellentesque nisi nunc risus enim sem lacinia et rutrum erat felis", "Dui laoreet", "elementum-interdum" },
                    { 6, "Amet quisque orci sapien quis vulputate consequat laoreet malesuada nisl enim tincidunt", "Leo nam", "bibendum-magna" },
                    { 7, "Tempor adipiscing eros quisque orci massa quis himenaeos litora ad nibh enim", "Amet eu", "tellus-sagittis" },
                    { 8, "Elit proin rhoncus sit non mollis iaculis consequat feugiat eros morbi nulla", "Viverra urna", "rhoncus-ultrices" },
                    { 9, "Accumsan erat facilisis amet metus neque bibendum molestie nam eget felis dictum", "Laoreet massa", "varius-lacus" },
                    { 10, "Arcu ornare sagittis mollis euismod faucibus commodo nullam dignissim blandit tempor eros", "Felis mattis", "lacus-blandit" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15d38edc-87c6-4c1e-a3b9-26729c8e1269", "c4fa74ab-2974-4af3-a766-3b98947ca4e3", "Admin", "ADMIN" },
                    { "305bd8bf-90e0-4adb-8464-5985f70456ea", "d638a1d1-4bdf-4c5a-aee0-2d4e6d6d704b", "User", "USER" },
                    { "e484c8c4-1e3f-4049-ac5a-26f0d81dcde8", "39ad0290-559c-4aaf-8604-f2f268f0e7b1", "Blog Owner", "BLOG OWNER" },
                    { "f61e1d7f-8683-49cb-ab34-174cbda6dddb", "a809396c-c072-41c5-907c-00696f054ae6", "Contributor", "CONTRIBUTOR" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 24, "Nulla vel class nibh ultricies pulvinar sollicitudin magna ipsum elit aenean sodales luctus", "In feugiat suscipit", "cursus-semper-elit" },
                    { 2, 14, "Ultricies sed viverra ultrices tortor interdum pulvinar massa velit consectetur vel augue purus", "Massa rutrum mauris", "neque-scelerisque-fringilla" },
                    { 3, 14, "Phasellus enim a nullam accumsan non in vitae feugiat laoreet imperdiet posuere elementum", "Convallis placerat finibus", "nunc-phasellus-consectetur" },
                    { 4, 23, "Rhoncus dictum dui efficitur pharetra dolor justo vel fringilla mattis neque et ad", "Vitae tellus mauris", "consectetur-ad-felis" },
                    { 5, 23, "Aptent sodales leo tortor ultrices faucibus vitae nisl lorem ultricies libero placerat phasellus", "Arcu massa quis", "lacinia-taciti-cras" },
                    { 6, 15, "Bibendum dapibus efficitur eros faucibus dictumst eleifend elit nunc velit gravida vivamus cras", "Interdum libero fringilla", "congue-felis-id" },
                    { 7, 21, "Placerat et fringilla eros vivamus enim feugiat quam quam volutpat inceptos nostra ex", "Non ex odio", "orci-vulputate-sapien" },
                    { 8, 28, "Facilisis sem inceptos odio enim interdum volutpat dapibus lacinia malesuada accumsan nunc suspendisse", "Est dolor rhoncus", "curabitur-nulla-vitae" },
                    { 9, 27, "Sodales orci lobortis nunc urna efficitur ligula interdum gravida laoreet hac erat integer", "Vitae massa vehicula", "finibus-elementum-hac" },
                    { 10, 19, "Vitae rutrum odio arcu maecenas sodales nibh odio dui ex augue tortor congue", "At quam orci", "torquent-auctor-magna" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AboutMe", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "05ce7ad2-96c9-460b-a568-b4f0a8df9cd7", "Ultrices congue quis varius mattis eu maximus eu ac pellentesque", 0, 43, "9bbff195-19a4-4da2-9f07-0b0775e8483b", "truongan123@gmail.com", true, false, null, "TRUONGAN123@GMAIL.COM", "TRUONGAN123", "AQAAAAEAACcQAAAAEO5k9kBvvLpdxhZaXWNZliqO8pydt5zxQleUVoR/oLBBq6J4bpz9FAHXpPrqTtot8A==", null, false, "6dc118c2-a4a4-4bf6-bcb7-16ab682d7730", false, "truongan123" },
                    { "1b4b227b-7ebb-4683-8560-e7367edd8ad9", "Porttitor malesuada ornare blandit pellentesque hendrerit pretium ultrices augue phasellus", 0, 43, "226b1b3e-a835-421e-8d8c-77b157620bf4", "truongan1234@gmail.com", true, false, null, "TRUONGAN1234@GMAIL.COM", "TRUONGAN1234", "AQAAAAEAACcQAAAAEISddh/Bz6e5+sKWHQHYENfmrX/IdCOCC9fuqVFgjWSkVpxWOWZap249CjnHj7SQkw==", null, false, "9ea78498-97fd-4dfd-ae65-15b83fd8ecac", false, "truongan1234" },
                    { "83209156-f2e9-4e8e-b1c5-39d809d736b9", "Eu lorem primis torquent eros dictumst platea per tempor ante", 0, 47, "ebc5ec7d-6e81-466a-be6e-ddce3cd18714", "truongan12345@gmail.com", true, false, null, "TRUONGAN12345@GMAIL.COM", "TRUONGAN12345", "AQAAAAEAACcQAAAAEPfjb22BnEoJ5qgDevG5u1T4aE87CkEfP7rHgbgeFQxwuaqHQEfEuSQzI4yaGdCM8g==", null, false, "6f0ec20f-0c50-49a1-83f3-fcbc0c9f0841", false, "truongan12345" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "Post Content", "Posted On", "Published", "Rate Count", "Short Description", "Title", "Total Rate", "UrlSlug", "View Count" },
                values: new object[,]
                {
                    { 1, 2, null, "Nibh quam, class mattis eleifend laoreet dignissim massa, nisi, lobortis a vitae, tristique. Phasellus turpis at ut conubia ultrices, eu bibendum, odio hac nec, tortor ante, a ante at, cras mollis. Cursus, blandit ad lorem viverra interdum nullam sem, quis malesuada sollicitudin auctor cursus. Suspendisse lorem ante eget pulvinar enim, volutpat consequat magna praesent blandit, fusce elit, facilisis bibendum, condimentum. Enim egestas sed, convallis fusce commodo, arcu, tincidunt scelerisque enim.", new DateTime(2023, 9, 2, 8, 1, 12, 880, DateTimeKind.Local).AddTicks(968), true, 28, "Porttitor mi curabitur arcu mauris sociosqu gravida suscipit luctus odio lacinia congue sed", "Leo adipiscing porttitor", 184, "aenean-iaculis-sed", 253 },
                    { 2, 1, null, "Congue, ipsum libero erat vivamus sit tristique aptent vel, viverra rhoncus lacus nam. Lorem erat felis nam maximus pulvinar, vestibulum sagittis, mattis interdum ac, cursus tempor congue. Tortor, quam nec, nostra, diam eget porta et rhoncus, ligula, eleifend duis. Dolor, congue, sed vulputate per amet efficitur diam dapibus purus mauris, accumsan proin magna erat ipsum vehicula. Justo euismod, tempor nisi cras ante, odio ornare eu, nullam mattis fringilla vel, volutpat ultrices, nunc, eros hendrerit. Elit urna, varius pretium auctor amet sem laoreet, accumsan ligula. Odio, arcu, a, blandit dignissim maecenas posuere, mattis ante quam hendrerit nunc sollicitudin maximus vulputate volutpat, varius imperdiet.", new DateTime(2023, 9, 2, 5, 53, 12, 880, DateTimeKind.Local).AddTicks(4117), true, 27, "Enim lacinia arcu scelerisque fringilla congue erat nullam sed laoreet maecenas tortor finibus", "Fringilla tellus posuere", 200, "odio-quam-iaculis", 288 },
                    { 3, 4, null, "Dictumst ultricies fusce eros, ut tincidunt feugiat taciti dui, rutrum sociosqu facilisis duis gravida fringilla, in. Nec, duis efficitur tortor bibendum, ante, dapibus vehicula dictum quis porta habitasse facilisis ultrices. Mauris maecenas ante, in primis convallis orci, platea porttitor, efficitur taciti eros, pulvinar, egestas odio, semper. Ex, a leo pulvinar, metus orci, vehicula ex porttitor euismod, velit libero aliquet. Lectus, imperdiet rutrum velit eu nibh placerat, dolor fringilla mollis. In cras nisi ultricies vitae dolor, aptent quam, faucibus amet primis mi praesent ultrices hac. Sit auctor, rhoncus, donec curabitur morbi fames taciti tortor, justo ornare nulla in, ad mi, euismod, lacus non sagittis.", new DateTime(2023, 9, 7, 15, 24, 12, 880, DateTimeKind.Local).AddTicks(7250), true, 21, "Non vitae massa pellentesque proin urna neque tortor molestie non commodo porttitor in", "Ex sapien quam", 164, "et-suscipit-lorem", 127 },
                    { 4, 5, null, "Tempor, mi, porta, posuere quisque lacus lacinia placerat vel dolor, tincidunt bibendum, orci, per nibh lacinia, mauris quis. Lorem pulvinar, mollis fames maximus morbi non ligula, placerat est. Sollicitudin pretium scelerisque eleifend laoreet mattis vel mollis sagittis inceptos massa, lobortis sed ligula, tempor, integer porttitor, at eleifend. Sed, ultrices ultrices, mattis phasellus metus placerat, nec, nulla dignissim vehicula a quam finibus. Quis, commodo, feugiat, nisi risus adipiscing eros, ornare sit ultrices. Tempor fames leo nunc, imperdiet feugiat, dictumst libero mi, maecenas. Finibus, et, justo laoreet lacinia facilisis dolor lacinia, torquent turpis tempus elementum laoreet, vivamus.", new DateTime(2023, 8, 31, 16, 22, 12, 881, DateTimeKind.Local).AddTicks(272), true, 23, "Fringilla nec interdum tortor porta vestibulum luctus malesuada bibendum posuere fusce dolor mauris", "Mollis purus litora", 104, "pellentesque-cursus-fermentum", 273 },
                    { 5, 3, null, "Interdum, maximus fringilla, at urna, nibh ultrices ad urna curabitur primis magna blandit. Bibendum eu, egestas dignissim diam phasellus himenaeos lorem lectus hendrerit justo. Id phasellus sodales lectus, mi elit, morbi finibus auctor amet, tempus platea urna, vitae, ac molestie sapien integer. Dignissim sem, conubia pulvinar, vulputate neque hac vivamus turpis lobortis vel.", new DateTime(2023, 9, 7, 21, 31, 12, 881, DateTimeKind.Local).AddTicks(2302), true, 21, "Ac taciti fermentum lorem blandit mattis tortor tristique integer ligula aliquet quis inceptos", "Amet ornare lacinia", 274, "felis-luctus-et", 244 },
                    { 6, 3, null, "Ultrices, lectus sed, pulvinar dictumst vestibulum laoreet, id platea adipiscing mattis ante, tellus sociosqu vitae, est fusce. Massa, felis augue auctor, magna, feugiat, sem, vestibulum, pellentesque arcu taciti eget elementum proin. Imperdiet quam, aliquet suspendisse mi, ex, tortor porta, scelerisque mi fringilla, non, tellus placerat, maximus. Turpis pharetra tellus odio tortor nisl mauris, eleifend, malesuada mattis, ultricies enim. Sagittis risus sem praesent urna, maximus porta, id vestibulum facilisis nulla, maecenas ligula, suscipit rutrum magna, non tempus. Quam maximus ante finibus eleifend, ante, commodo semper litora eget cursus placerat, sem, duis imperdiet.", new DateTime(2023, 9, 5, 9, 28, 12, 886, DateTimeKind.Local).AddTicks(8903), true, 15, "Volutpat auctor viverra praesent et ipsum hendrerit lobortis eget pellentesque hac elementum arcu", "Arcu dolor odio", 153, "sollicitudin-purus-ex", 132 },
                    { 7, 1, null, "Dolor lacus vestibulum a, imperdiet porttitor magna id, conubia lacinia dolor, rhoncus tellus, mauris blandit, gravida. In, nibh mattis, elit, purus mi malesuada gravida urna feugiat pulvinar. Vivamus vestibulum, urna vestibulum condimentum suspendisse mauris augue gravida nunc, vehicula dictumst massa placerat nisi, rhoncus ante dolor. Varius class vel, enim lacus mi a placerat, eleifend, vestibulum, odio, aliquet enim, adipiscing donec.", new DateTime(2023, 9, 7, 8, 6, 12, 887, DateTimeKind.Local).AddTicks(1534), true, 23, "Aliquam interdum non rhoncus nibh sociosqu primis mi ultricies per amet malesuada at", "Commodo accumsan ullamcorper", 225, "non-finibus-tempus", 293 },
                    { 8, 5, null, "Cursus, phasellus vehicula tristique primis vel ad nullam ac, auctor, ex, tellus, ultricies erat tempor, cursus. Nec, sapien lobortis tempus venenatis fringilla, sociosqu erat nostra, vivamus condimentum eget massa. Inceptos auctor massa, platea sit urna, adipiscing ullamcorper magna et. Dictum inceptos egestas turpis quis, dapibus ultrices lacinia ligula, nullam ipsum enim, eleifend fusce dui. Laoreet consequat tincidunt maximus metus lobortis neque, a, sagittis quis. At, sapien odio, mauris sem, elementum cras porttitor dui, nostra, maecenas sem risus ultrices, ullamcorper fringilla, scelerisque posuere donec. Taciti est purus inceptos faucibus urna, mattis scelerisque aliquam vestibulum, nisi imperdiet a, ac rutrum cursus, semper tristique.", new DateTime(2023, 9, 3, 3, 11, 12, 887, DateTimeKind.Local).AddTicks(4635), true, 25, "Luctus mi aenean maecenas quam ante luctus hendrerit mauris lacus interdum blandit sit", "Integer vulputate posuere", 286, "pellentesque-rhoncus-mauris", 259 },
                    { 9, 4, null, "Fringilla, odio turpis tortor rhoncus, eu litora arcu, ante, iaculis pretium sagittis eleifend, blandit, eu, lorem. Ultrices, pulvinar, feugiat, velit tempor interdum, arcu eu, at id. Nec, conubia elementum imperdiet risus cras libero aptent himenaeos sem, enim bibendum, placerat, fusce. Congue suspendisse eleifend praesent id, fusce velit nibh, litora vivamus vestibulum conubia odio, odio venenatis.", new DateTime(2023, 9, 4, 4, 18, 12, 887, DateTimeKind.Local).AddTicks(6770), true, 19, "Lacus est luctus nisi enim vivamus urna eget nulla semper nostra phasellus id", "Elit non dapibus", 201, "lorem-aliquet-sem", 171 },
                    { 10, 3, null, "Primis fermentum vehicula class fames magna, sed, purus per donec habitasse tellus ipsum tempor. Massa, sed nunc nisi urna odio, porttitor, vitae, magna, vulputate adipiscing sagittis ut ultricies pulvinar, fames vehicula. Et finibus, tempus class iaculis gravida ullamcorper etiam justo laoreet, hendrerit arcu, cursus urna, quam, integer. Neque varius non quis, orci vestibulum erat, finibus ultricies lacinia eu nisi. Massa, lectus ipsum efficitur metus libero bibendum ante fusce curabitur. Volutpat nisi vulputate fusce nibh, dictum amet, lacus justo interdum tincidunt neque laoreet odio euismod, consequat pulvinar, nullam lorem. Lectus eu quam, interdum in, nisi nisi, magna ultricies auctor, morbi donec erat, metus.", new DateTime(2023, 8, 31, 22, 52, 12, 887, DateTimeKind.Local).AddTicks(9603), true, 19, "Tempor luctus congue velit pretium magna ex ligula praesent dui convallis lorem placerat", "Laoreet donec mi", 280, "iaculis-duis-nibh", 230 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e484c8c4-1e3f-4049-ac5a-26f0d81dcde8", "05ce7ad2-96c9-460b-a568-b4f0a8df9cd7" },
                    { "f61e1d7f-8683-49cb-ab34-174cbda6dddb", "1b4b227b-7ebb-4683-8560-e7367edd8ad9" },
                    { "305bd8bf-90e0-4adb-8464-5985f70456ea", "83209156-f2e9-4e8e-b1c5-39d809d736b9" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "Nibh eu sodales", "Erat, ac, orci, leo ex non torquent nisi, pretium eleifend nostra.", new DateTime(2023, 9, 1, 2, 44, 12, 888, DateTimeKind.Local).AddTicks(8834), "commodo@amet.com", "Nulla neque", 4 },
                    { 2, "Quisque eros urna", "Lectus massa amet sociosqu aliquet erat platea placerat, sodales maecenas ultricies tempor, quisque.", new DateTime(2023, 8, 31, 3, 17, 12, 888, DateTimeKind.Local).AddTicks(9949), "sed@aliquet.com", "Ex leo", 1 },
                    { 3, "Sem ullamcorper vulputate", "Adipiscing tempor, orci, finibus lorem, arcu, porta, a, mauris, nisl quisque sed taciti ligula, elit et sem.", new DateTime(2023, 9, 2, 17, 56, 12, 889, DateTimeKind.Local).AddTicks(1036), "tortor@nullam.com", "Cras aptent", 5 },
                    { 4, "Placerat euismod ante", "Ligula auctor nam euismod, eros, condimentum ligula, hac finibus euismod a odio, adipiscing metus sollicitudin dictumst. Morbi rhoncus consequat porta tincidunt feugiat, integer quam, nisi, lacinia, phasellus ultricies.", new DateTime(2023, 9, 2, 10, 43, 12, 889, DateTimeKind.Local).AddTicks(2346), "nam@posuere.com", "Auctor massa", 9 },
                    { 5, "Morbi pellentesque aptent", "Eu, volutpat vitae, auctor luctus, dictum porttitor cursus taciti dolor ipsum. Turpis interdum massa maximus dolor varius commodo, dui ad neque diam erat elit, facilisis pulvinar, augue vestibulum, urna, dapibus.", new DateTime(2023, 8, 31, 0, 59, 12, 889, DateTimeKind.Local).AddTicks(3761), "nisi@adipiscing.com", "Ornare bibendum", 2 },
                    { 6, "Quisque augue sem", "Nunc in elit, bibendum, ex, imperdiet vitae, tempor in, nostra, praesent euismod fusce porta, euismod, lorem. Sed odio, auctor inceptos nibh, felis sodales quis, tortor quisque non lobortis quis ultricies vel, tortor, erat, class et.", new DateTime(2023, 9, 7, 23, 52, 12, 889, DateTimeKind.Local).AddTicks(5104), "per@aliquam.com", "Massa commodo", 8 },
                    { 7, "Auctor odio urna", "Ligula scelerisque cras arcu, vel nisi, consequat dictum convallis rutrum cursus leo, tempus ut mattis. Fringilla in, donec ut nunc, a, hendrerit nam faucibus nisi magna, congue torquent arcu, himenaeos rutrum ante ex, eleifend.", new DateTime(2023, 9, 1, 3, 40, 12, 889, DateTimeKind.Local).AddTicks(6474), "tempor@pellentesque.com", "Turpis sagittis", 4 },
                    { 8, "Enim rhoncus ut", "Bibendum, elit, tincidunt quam, ornare orci, ut cursus, ultricies tempor dolor, aliquam sagittis, posuere, turpis dictum. Fusce eleifend, mattis, scelerisque at, duis vel urna blandit eleifend dolor leo lectus, cursus.", new DateTime(2023, 8, 31, 20, 0, 12, 889, DateTimeKind.Local).AddTicks(7826), "est@neque.com", "Massa rhoncus", 9 },
                    { 9, "Nunc inceptos dolor", "Sed, leo quam, amet, dapibus per vel, nibh, quis, in erat, nostra, ante mollis pretium fusce eu, a, bibendum. Nostra, luctus, litora quam, pulvinar, adipiscing quam nibh, commodo, dui in eleifend dictum fusce ac rutrum.", new DateTime(2023, 9, 4, 3, 10, 12, 889, DateTimeKind.Local).AddTicks(9134), "mauris@bibendum.com", "Non elit", 6 },
                    { 10, "Rutrum feugiat lorem", "Bibendum etiam leo arcu taciti bibendum, class vitae, sed, ante rutrum mi inceptos blandit, eros, primis euismod, fames pulvinar. Augue tempor, at justo fringilla finibus accumsan est rutrum porta varius, pellentesque metus porttitor tristique ornare urna.", new DateTime(2023, 9, 7, 23, 32, 12, 890, DateTimeKind.Local).AddTicks(478), "feugiat@egestas.com", "Vehicula mattis", 8 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_TagId",
                table: "PostTagMaps",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTagMaps");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

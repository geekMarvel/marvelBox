using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetShop.Client.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lifespan = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Birds" },
                    { 2, "Mammals" },
                    { 3, "Reptiles" },
                    { 4, "Amphibians" },
                    { 5, "Fish" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CategoryId", "Description", "Lifespan", "Name", "PhotoUrl" },
                values: new object[,]
                {
                    { 1, 1, "Eagles are large and powerfully built, and are often referred to as the king of all birds. Eagles have heavy heads and beaks, which are hooked for ripping flesh from prey. Their legs are muscular and their talons are strong, making them a deadly predator.", 30, "Eagle", "eagle.jpg" },
                    { 2, 1, "Most owls have huge heads, stocky bodies, soft feathers, short tails, and a reversible toe that can point either forward or backward. Owl's eyes face forward, like humans do. Most owl species are active at night, not in the daytime. There are about 250 species of owls in the world.", 20, "Owl", "owl.jpg" },
                    { 3, 1, "Swans are gracefully long-necked, heavy-bodied, big-footed birds that glide majestically when swimming and fly with slow wingbeats and with necks outstretched. They migrate in diagonal formation or V-formation at great heights, and no other waterfowl moves as fast on the water or in the air.", 15, "Swan", "swan.jpg" },
                    { 4, 2, "Tigers have reddish-orange coats with prominent black stripes, white bellies and white spots on their ears. Like a human fingerprint, no two tigers have the exact same markings. Because of this, researchers can use stripe patterns to identify different individuals when studying tigers in the wild.", 15, "Tiger", "tiger.jpg" },
                    { 5, 2, "Lions have strong, compact bodies and powerful forelegs, teeth and jaws for pulling down and killing prey. Their coats are yellow-gold, and adult males have shaggy manes that range in color from blond to reddish-brown to black.", 15, "Lion", "lion.jpg" },
                    { 6, 2, "The giraffe is the tallest of all mammals. It reaches an overall height of 18 ft (5.5 m) or more. The legs and neck are extremely long. The giraffe has a short body, a tufted tail, a short mane, and short skin-covered horns.", 25, "Giraffe", "giraffe.jpg" },
                    { 7, 3, "Snake, Any member of about 19 reptile families (suborder Serpentes, order Squamata) that has no limbs, voice, external ears, or eyelids, only one functional lung, and a long, slender body. About 2,900 snake species are known to exist, most living in the tropics.", 20, "Snake", "snake.jpg" },
                    { 8, 3, "In general, lizards have a small head, short neck, and long body and tail. Unlike snakes, most lizards have moveable eyelids. There are currently over 4,675 lizard species, including iguanas, chameleons, geckos, Gila monsters, monitors, and skinks.", 10, "Lizard", "lizard.jpg" },
                    { 9, 4, "A frog has smooth, moist skin and big, bulging eyes. Its hind legs are more than twice as long as its front ones. Most frogs have webbed back feet to help them leap and swim. Tree frogs have sticky disks on the tips of their fingers and toes.", 10, "Frog", "frog.jpg" },
                    { 10, 4, "Salamanders encompass approximately 500 species of amphibians. They typically have slender bodies, short legs, and long tails. Usually found in moist or arid habitats in the northern hemisphere, most salamanders are small, although there are two species that reach up to 5 feet in length.", 15, "Salamanders", "salamanders.jpg" },
                    { 11, 5, "Seahorses are tiny fishes that are named for the shape of their head, which looks like the head of a tiny horse. There are at least 50 species of seahorses. You'll find seahorses in the world's tropical and temperate coastal waters, swimming upright among seaweed and other plants.", 5, "Seahorse", "seahorse.jpg" },
                    { 12, 5, "Sharks are fishes and most have the typical fusiform body shape. Like other fishes, sharks are ectothermic (cold-blooded), live in water, have fins, and breathe with gills. However, sharks differ from Osteichthyes fish. One difference is that a shark's skeleton is made of cartilage instead of bone.", 30, "Shark", "shark.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "AnimalId", "Text" },
                values: new object[,]
                {
                    { 1, 12, "Once your blood's in the water, everyone's a shark!" },
                    { 2, 7, "The snake will always bite back." },
                    { 3, 1, "Don't quack like a duck, soar like an eagle." },
                    { 4, 5, "A lion is called a 'king of beasts' obviously for a reason." },
                    { 5, 2, "There's always a hidden owl in knowledge." },
                    { 6, 6, "They're officially the tallest animal." },
                    { 7, 1, "The eagle has no fear of adversity." },
                    { 8, 5, "It's better to be a lion for a day than a sheep all your life." },
                    { 9, 1, "You can put wings on a pig, but you don't make it an eagle." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryId",
                table: "Animals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimalId",
                table: "Comments",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

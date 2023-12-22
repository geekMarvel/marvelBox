﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetShop.Data.Contexts;

#nullable disable

namespace PetShop.Client.Migrations
{
    [DbContext(typeof(PetShopDbContext))]
    [Migration("20231206192401_additionCheck")]
    partial class additionCheck
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetShop.Models.Entities.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnimalId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Lifespan")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimalId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            CategoryId = 1,
                            Description = "Eagles are large and powerfully built, and are often referred to as the king of all birds. Eagles have heavy heads and beaks, which are hooked for ripping flesh from prey. Their legs are muscular and their talons are strong, making them a deadly predator.",
                            Lifespan = 30,
                            Name = "Eagle",
                            PhotoUrl = "eagle.jpg"
                        },
                        new
                        {
                            AnimalId = 2,
                            CategoryId = 1,
                            Description = "Most owls have huge heads, stocky bodies, soft feathers, short tails, and a reversible toe that can point either forward or backward. Owl's eyes face forward, like humans do. Most owl species are active at night, not in the daytime. There are about 250 species of owls in the world.",
                            Lifespan = 20,
                            Name = "Owl",
                            PhotoUrl = "owl.jpg"
                        },
                        new
                        {
                            AnimalId = 3,
                            CategoryId = 1,
                            Description = "Swans are gracefully long-necked, heavy-bodied, big-footed birds that glide majestically when swimming and fly with slow wingbeats and with necks outstretched. They migrate in diagonal formation or V-formation at great heights, and no other waterfowl moves as fast on the water or in the air.",
                            Lifespan = 15,
                            Name = "Swan",
                            PhotoUrl = "swan.jpg"
                        },
                        new
                        {
                            AnimalId = 4,
                            CategoryId = 2,
                            Description = "Tigers have reddish-orange coats with prominent black stripes, white bellies and white spots on their ears. Like a human fingerprint, no two tigers have the exact same markings. Because of this, researchers can use stripe patterns to identify different individuals when studying tigers in the wild.",
                            Lifespan = 15,
                            Name = "Tiger",
                            PhotoUrl = "tiger.jpg"
                        },
                        new
                        {
                            AnimalId = 5,
                            CategoryId = 2,
                            Description = "Lions have strong, compact bodies and powerful forelegs, teeth and jaws for pulling down and killing prey. Their coats are yellow-gold, and adult males have shaggy manes that range in color from blond to reddish-brown to black.",
                            Lifespan = 15,
                            Name = "Lion",
                            PhotoUrl = "lion.jpg"
                        },
                        new
                        {
                            AnimalId = 6,
                            CategoryId = 2,
                            Description = "The giraffe is the tallest of all mammals. It reaches an overall height of 18 ft (5.5 m) or more. The legs and neck are extremely long. The giraffe has a short body, a tufted tail, a short mane, and short skin-covered horns.",
                            Lifespan = 25,
                            Name = "Giraffe",
                            PhotoUrl = "giraffe.jpg"
                        },
                        new
                        {
                            AnimalId = 7,
                            CategoryId = 3,
                            Description = "Snake, Any member of about 19 reptile families (suborder Serpentes, order Squamata) that has no limbs, voice, external ears, or eyelids, only one functional lung, and a long, slender body. About 2,900 snake species are known to exist, most living in the tropics.",
                            Lifespan = 20,
                            Name = "Snake",
                            PhotoUrl = "snake.jpg"
                        },
                        new
                        {
                            AnimalId = 8,
                            CategoryId = 3,
                            Description = "In general, lizards have a small head, short neck, and long body and tail. Unlike snakes, most lizards have moveable eyelids. There are currently over 4,675 lizard species, including iguanas, chameleons, geckos, Gila monsters, monitors, and skinks.",
                            Lifespan = 10,
                            Name = "Lizard",
                            PhotoUrl = "lizard.jpg"
                        },
                        new
                        {
                            AnimalId = 9,
                            CategoryId = 4,
                            Description = "A frog has smooth, moist skin and big, bulging eyes. Its hind legs are more than twice as long as its front ones. Most frogs have webbed back feet to help them leap and swim. Tree frogs have sticky disks on the tips of their fingers and toes.",
                            Lifespan = 10,
                            Name = "Frog",
                            PhotoUrl = "frog.jpg"
                        },
                        new
                        {
                            AnimalId = 10,
                            CategoryId = 4,
                            Description = "Salamanders encompass approximately 500 species of amphibians. They typically have slender bodies, short legs, and long tails. Usually found in moist or arid habitats in the northern hemisphere, most salamanders are small, although there are two species that reach up to 5 feet in length.",
                            Lifespan = 15,
                            Name = "Salamanders",
                            PhotoUrl = "salamanders.jpg"
                        },
                        new
                        {
                            AnimalId = 11,
                            CategoryId = 5,
                            Description = "Seahorses are tiny fishes that are named for the shape of their head, which looks like the head of a tiny horse. There are at least 50 species of seahorses. You'll find seahorses in the world's tropical and temperate coastal waters, swimming upright among seaweed and other plants.",
                            Lifespan = 5,
                            Name = "Seahorse",
                            PhotoUrl = "seahorse.jpg"
                        },
                        new
                        {
                            AnimalId = 12,
                            CategoryId = 5,
                            Description = "Sharks are fishes and most have the typical fusiform body shape. Like other fishes, sharks are ectothermic (cold-blooded), live in water, have fins, and breathe with gills. However, sharks differ from Osteichthyes fish. One difference is that a shark's skeleton is made of cartilage instead of bone.",
                            Lifespan = 30,
                            Name = "Shark",
                            PhotoUrl = "shark.jpg"
                        });
                });

            modelBuilder.Entity("PetShop.Models.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Birds"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Mammals"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Reptiles"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Amphibians"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Fish"
                        });
                });

            modelBuilder.Entity("PetShop.Models.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentId");

                    b.HasIndex("AnimalId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            AnimalId = 12,
                            Text = "Once your blood's in the water, everyone's a shark!"
                        },
                        new
                        {
                            CommentId = 2,
                            AnimalId = 7,
                            Text = "The snake will always bite back."
                        },
                        new
                        {
                            CommentId = 3,
                            AnimalId = 1,
                            Text = "Don't quack like a duck, soar like an eagle."
                        },
                        new
                        {
                            CommentId = 4,
                            AnimalId = 5,
                            Text = "A lion is called a 'king of beasts' obviously for a reason."
                        },
                        new
                        {
                            CommentId = 5,
                            AnimalId = 2,
                            Text = "There's always a hidden owl in knowledge."
                        },
                        new
                        {
                            CommentId = 6,
                            AnimalId = 6,
                            Text = "They're officially the tallest animal."
                        },
                        new
                        {
                            CommentId = 7,
                            AnimalId = 1,
                            Text = "The eagle has no fear of adversity."
                        },
                        new
                        {
                            CommentId = 8,
                            AnimalId = 5,
                            Text = "It's better to be a lion for a day than a sheep all your life."
                        },
                        new
                        {
                            CommentId = 9,
                            AnimalId = 1,
                            Text = "You can put wings on a pig, but you don't make it an eagle."
                        });
                });

            modelBuilder.Entity("PetShop.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PetShop.Models.Entities.Animal", b =>
                {
                    b.HasOne("PetShop.Models.Entities.Category", null)
                        .WithMany("Animals")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PetShop.Models.Entities.Comment", b =>
                {
                    b.HasOne("PetShop.Models.Entities.Animal", null)
                        .WithMany("Comments")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PetShop.Models.Entities.Animal", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("PetShop.Models.Entities.Category", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShop.Models.Entities;

namespace PetShop.Data.Contexts;

public class PetShopDbContext : DbContext
{
    public PetShopDbContext(DbContextOptions<PetShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            //entity.Property(e => e.Name).HasMaxLength(50);

            //entity.HasOne(d => d.Category).WithMany(p => p.Animals)
            //    .HasForeignKey(d => d.CategoryId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Animals_Categories");

            entity.HasData(
               new { AnimalId = 1, Name = "Eagle", CategoryId = 1, Lifespan = 30, Description = "Eagles are large and powerfully built, and are often referred to as the king of all birds. Eagles have heavy heads and beaks, which are hooked for ripping flesh from prey. Their legs are muscular and their talons are strong, making them a deadly predator.", PhotoUrl = "eagle.jpg" },
                new { AnimalId = 2, Name = "Owl", CategoryId = 1, Lifespan = 20, Description = "Most owls have huge heads, stocky bodies, soft feathers, short tails, and a reversible toe that can point either forward or backward. Owl's eyes face forward, like humans do. Most owl species are active at night, not in the daytime. There are about 250 species of owls in the world.", PhotoUrl = "owl.jpg" },
                new { AnimalId = 3, Name = "Swan", CategoryId = 1, Lifespan = 15, Description = "Swans are gracefully long-necked, heavy-bodied, big-footed birds that glide majestically when swimming and fly with slow wingbeats and with necks outstretched. They migrate in diagonal formation or V-formation at great heights, and no other waterfowl moves as fast on the water or in the air.", PhotoUrl = "swan.jpg" },
                new { AnimalId = 4, Name = "Tiger", CategoryId = 2, Lifespan = 15, Description = "Tigers have reddish-orange coats with prominent black stripes, white bellies and white spots on their ears. Like a human fingerprint, no two tigers have the exact same markings. Because of this, researchers can use stripe patterns to identify different individuals when studying tigers in the wild.", PhotoUrl = "tiger.jpg" },
                new { AnimalId = 5, Name = "Lion", CategoryId = 2, Lifespan = 15, Description = "Lions have strong, compact bodies and powerful forelegs, teeth and jaws for pulling down and killing prey. Their coats are yellow-gold, and adult males have shaggy manes that range in color from blond to reddish-brown to black.", PhotoUrl = "lion.jpg" },
                new { AnimalId = 6, Name = "Giraffe", CategoryId = 2, Lifespan = 25, Description = "The giraffe is the tallest of all mammals. It reaches an overall height of 18 ft (5.5 m) or more. The legs and neck are extremely long. The giraffe has a short body, a tufted tail, a short mane, and short skin-covered horns.", PhotoUrl = "giraffe.jpg" },
                new { AnimalId = 7, Name = "Snake", CategoryId = 3, Lifespan = 20, Description = "Snake, Any member of about 19 reptile families (suborder Serpentes, order Squamata) that has no limbs, voice, external ears, or eyelids, only one functional lung, and a long, slender body. About 2,900 snake species are known to exist, most living in the tropics.", PhotoUrl = "snake.jpg" },
                new { AnimalId = 8, Name = "Lizard", CategoryId = 3, Lifespan = 10, Description = "In general, lizards have a small head, short neck, and long body and tail. Unlike snakes, most lizards have moveable eyelids. There are currently over 4,675 lizard species, including iguanas, chameleons, geckos, Gila monsters, monitors, and skinks.", PhotoUrl = "lizard.jpg" },
                new { AnimalId = 9, Name = "Frog", CategoryId = 4, Lifespan = 10, Description = "A frog has smooth, moist skin and big, bulging eyes. Its hind legs are more than twice as long as its front ones. Most frogs have webbed back feet to help them leap and swim. Tree frogs have sticky disks on the tips of their fingers and toes.", PhotoUrl = "frog.jpg" },
                new { AnimalId = 10, Name = "Salamanders", CategoryId = 4, Lifespan = 15, Description = "Salamanders encompass approximately 500 species of amphibians. They typically have slender bodies, short legs, and long tails. Usually found in moist or arid habitats in the northern hemisphere, most salamanders are small, although there are two species that reach up to 5 feet in length.", PhotoUrl = "salamanders.jpg" },
                new { AnimalId = 11, Name = "Seahorse", CategoryId = 5, Lifespan = 5, Description = "Seahorses are tiny fishes that are named for the shape of their head, which looks like the head of a tiny horse. There are at least 50 species of seahorses. You'll find seahorses in the world's tropical and temperate coastal waters, swimming upright among seaweed and other plants.", PhotoUrl = "seahorse.jpg" },
                new { AnimalId = 12, Name = "Shark", CategoryId = 5, Lifespan = 30, Description = "Sharks are fishes and most have the typical fusiform body shape. Like other fishes, sharks are ectothermic (cold-blooded), live in water, have fins, and breathe with gills. However, sharks differ from Osteichthyes fish. One difference is that a shark's skeleton is made of cartilage instead of bone.", PhotoUrl = "shark.jpg" }
                );
        });

        modelBuilder.Entity<Category>(entity =>
        {
            //entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasData(
                new { CategoryId = 1, Name = "Birds" },
                new { CategoryId = 2, Name = "Mammals" },
                new { CategoryId = 3, Name = "Reptiles" },
                new { CategoryId = 4, Name = "Amphibians" },
                new { CategoryId = 5, Name = "Fish" }
                );
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            //entity.HasOne(d => d.Animal).WithMany(p => p.Comments)
            //    .HasForeignKey(d => d.AnimalId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Comments_Animals");

            entity.HasData(
               new { CommentId = 1, AnimalId = 12, Text = "Once your blood's in the water, everyone's a shark!" },
                new { CommentId = 2, AnimalId = 7, Text = "The snake will always bite back." },
                new { CommentId = 3, AnimalId = 1, Text = "Don't quack like a duck, soar like an eagle." },
                new { CommentId = 4, AnimalId = 5, Text = "A lion is called a 'king of beasts' obviously for a reason." },
                new { CommentId = 5, AnimalId = 2, Text = "There's always a hidden owl in knowledge." },
                new { CommentId = 6, AnimalId = 6, Text = "They're officially the tallest animal." },
                new { CommentId = 7, AnimalId = 1, Text = "The eagle has no fear of adversity." },
                new { CommentId = 8, AnimalId = 5, Text = "It's better to be a lion for a day than a sheep all your life." },
                new { CommentId = 9, AnimalId = 1, Text = "You can put wings on a pig, but you don't make it an eagle." }
                );
        });

        modelBuilder.Entity<User>()
                    .Property(e => e.Role)
                    .HasConversion<string>();



        base.OnModelCreating(modelBuilder);
    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}






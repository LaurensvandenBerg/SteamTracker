﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SteamTracker.Data;

namespace SteamTracker.Data.Migrations
{
    [DbContext(typeof(SteamContext))]
    [Migration("20190310094434_AddOwnerShip")]
    partial class AddOwnerShip
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SteamTracker.Data.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("SteamTracker.Data.Models.OwnerShip", b =>
                {
                    b.Property<int>("GameId");

                    b.Property<string>("PlayerId");

                    b.Property<int>("PlayTime");

                    b.HasKey("GameId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("OwnerShips");
                });

            modelBuilder.Entity("SteamTracker.Data.Models.Player", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameCount");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SteamTracker.Data.Models.OwnerShip", b =>
                {
                    b.HasOne("SteamTracker.Data.Models.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .HasConstraintName("ForeignKey_Ownership_Game")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SteamTracker.Data.Models.Player", "Player")
                        .WithMany("Owns")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("ForeignKey_Ownership_Player")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

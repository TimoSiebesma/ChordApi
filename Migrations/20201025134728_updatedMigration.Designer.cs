﻿// <auto-generated />
using ChordApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChordApi.Migrations
{
    [DbContext(typeof(ChordApiContext))]
    [Migration("20201025134728_updatedMigration")]
    partial class updatedMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChordApi.Models.Chord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chords");
                });

            modelBuilder.Entity("ChordApi.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("ChordApi.Models.SongChord", b =>
                {
                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.Property<int>("ChordId")
                        .HasColumnType("int");

                    b.HasKey("SongId", "ChordId");

                    b.HasIndex("ChordId");

                    b.ToTable("SongChord");
                });

            modelBuilder.Entity("ChordApi.Models.SongChord", b =>
                {
                    b.HasOne("ChordApi.Models.Chord", "Chord")
                        .WithMany("SongChords")
                        .HasForeignKey("ChordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChordApi.Models.Song", "Song")
                        .WithMany("SongChords")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

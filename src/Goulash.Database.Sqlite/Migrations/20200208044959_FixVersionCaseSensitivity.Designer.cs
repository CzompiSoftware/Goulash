﻿// <auto-generated />
using System;
using Goulash.Database.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Goulash.Database.Sqlite.Migrations
{
    [DbContext(typeof(SqliteContext))]
    [Migration("20200208044959_FixVersionCaseSensitivity")]
    partial class FixVersionCaseSensitivity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Goulash.Core.Package", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Authors")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000);

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000);

                    b.Property<long>("Downloads")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasReadme")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IconUrl")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000);

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("TEXT COLLATE NOCASE")
                        .HasMaxLength(128);

                    b.Property<bool>("IsPrerelease")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<string>("LicenseUrl")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000);

                    b.Property<bool>("Listed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MinClientVersion")
                        .HasColumnType("TEXT")
                        .HasMaxLength(44);

                    b.Property<string>("NormalizedVersionString")
                        .IsRequired()
                        .HasColumnName("Version")
                        .HasColumnType("TEXT COLLATE NOCASE")
                        .HasMaxLength(64);

                    b.Property<string>("OriginalVersionString")
                        .HasColumnName("OriginalVersion")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<string>("ProjectUrl")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000);

                    b.Property<DateTime>("Published")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReleaseNotes")
                        .HasColumnName("ReleaseNotes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000);

                    b.Property<string>("RepositoryType")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("RepositoryUrl")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000);

                    b.Property<bool>("RequireLicenseAcceptance")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("SemVerLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000);

                    b.Property<string>("Tags")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000);

                    b.Property<string>("Title")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Key");

                    b.HasIndex("Id");

                    b.HasIndex("Id", "NormalizedVersionString")
                        .IsUnique();

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("Goulash.Core.PackageDependency", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Id")
                        .HasColumnType("TEXT COLLATE NOCASE")
                        .HasMaxLength(128);

                    b.Property<int?>("PackageKey")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TargetFramework")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("VersionRange")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Key");

                    b.HasIndex("Id");

                    b.HasIndex("PackageKey");

                    b.ToTable("PackageDependencies");
                });

            modelBuilder.Entity("Goulash.Core.PackageType", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT COLLATE NOCASE")
                        .HasMaxLength(512);

                    b.Property<int>("PackageKey")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Version")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.HasKey("Key");

                    b.HasIndex("Name");

                    b.HasIndex("PackageKey");

                    b.ToTable("PackageTypes");
                });

            modelBuilder.Entity("Goulash.Core.TargetFramework", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Moniker")
                        .HasColumnType("TEXT COLLATE NOCASE")
                        .HasMaxLength(256);

                    b.Property<int>("PackageKey")
                        .HasColumnType("INTEGER");

                    b.HasKey("Key");

                    b.HasIndex("Moniker");

                    b.HasIndex("PackageKey");

                    b.ToTable("TargetFrameworks");
                });

            modelBuilder.Entity("Goulash.Core.PackageDependency", b =>
                {
                    b.HasOne("Goulash.Core.Package", "Package")
                        .WithMany("Dependencies")
                        .HasForeignKey("PackageKey");
                });

            modelBuilder.Entity("Goulash.Core.PackageType", b =>
                {
                    b.HasOne("Goulash.Core.Package", "Package")
                        .WithMany("PackageTypes")
                        .HasForeignKey("PackageKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Goulash.Core.TargetFramework", b =>
                {
                    b.HasOne("Goulash.Core.Package", "Package")
                        .WithMany("TargetFrameworks")
                        .HasForeignKey("PackageKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

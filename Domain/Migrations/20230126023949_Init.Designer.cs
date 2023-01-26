﻿// <auto-generated />
using System;
using Domain.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace domain.Migrations
{
    [DbContext(typeof(RSSNewsDbContext))]
    [Migration("20230126023949_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Contracts.Database.Feed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT")
                        .HasColumnName("image");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_update");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("link");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("tbl_feeds", "public");
                });

            modelBuilder.Entity("Contracts.Database.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("link");

                    b.Property<DateTime>("PubDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("publication_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("tbl_posts", "public");
                });

            modelBuilder.Entity("Contracts.Database.Subscription", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<int>("FeedId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("feed_id");

                    b.HasKey("UserId", "FeedId");

                    b.HasIndex("FeedId");

                    b.ToTable("tbl_subscriptions", "public");
                });

            modelBuilder.Entity("Contracts.Database.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("tbl_users", "public");
                });

            modelBuilder.Entity("Contracts.Database.Post", b =>
                {
                    b.HasOne("Contracts.Database.Feed", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Contracts.Database.Subscription", b =>
                {
                    b.HasOne("Contracts.Database.Feed", "Feed")
                        .WithMany("Subscribers")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Contracts.Database.User", "User")
                        .WithMany("Subscriptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feed");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Contracts.Database.Feed", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("Subscribers");
                });

            modelBuilder.Entity("Contracts.Database.User", b =>
                {
                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
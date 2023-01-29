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
    [Migration("20230128235315_Init")]
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

                    b.Property<string>("Author")
                        .HasColumnType("TEXT")
                        .HasColumnName("author");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT")
                        .HasColumnName("category");

                    b.Property<string>("Copyright")
                        .HasColumnType("TEXT")
                        .HasColumnName("copyright");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("Docs")
                        .HasColumnType("TEXT")
                        .HasColumnName("docs");

                    b.Property<string>("Generator")
                        .HasColumnType("TEXT")
                        .HasColumnName("generator");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT")
                        .HasColumnName("image");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT")
                        .HasColumnName("language");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_update");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("link");

                    b.Property<string>("SkipDays")
                        .HasColumnType("TEXT")
                        .HasColumnName("skip_days");

                    b.Property<string>("SkipHours")
                        .HasColumnType("TEXT")
                        .HasColumnName("skip_hours");

                    b.Property<string>("TTL")
                        .HasColumnType("TEXT")
                        .HasColumnName("ttl");

                    b.Property<string>("TextInputDescription")
                        .HasColumnType("TEXT")
                        .HasColumnName("text_input_description");

                    b.Property<string>("TextInputLink")
                        .HasColumnType("TEXT")
                        .HasColumnName("text_input_link");

                    b.Property<string>("TextInputName")
                        .HasColumnType("TEXT")
                        .HasColumnName("text_input_name");

                    b.Property<string>("TextInputTitle")
                        .HasColumnType("TEXT")
                        .HasColumnName("text_input_title");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("tbl_feeds");
                });

            modelBuilder.Entity("Contracts.Database.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<int>("FeedId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("feed_id");

                    b.Property<string>("GUID")
                        .HasColumnType("TEXT")
                        .HasColumnName("guid");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT")
                        .HasColumnName("link");

                    b.Property<DateTime>("PubDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("publication_date");

                    b.Property<string>("Source")
                        .HasColumnType("TEXT")
                        .HasColumnName("source");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("FeedId");

                    b.ToTable("tbl_posts");
                });

            modelBuilder.Entity("Contracts.Database.ReadPost", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("post_id");

                    b.HasKey("UserId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("tbl_read_posts");
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

                    b.ToTable("tbl_subscriptions");
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

                    b.ToTable("tbl_users");
                });

            modelBuilder.Entity("Contracts.Database.Post", b =>
                {
                    b.HasOne("Contracts.Database.Feed", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Contracts.Database.ReadPost", b =>
                {
                    b.HasOne("Contracts.Database.Post", "Post")
                        .WithMany("ReadBy")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Contracts.Database.User", "User")
                        .WithMany("ReadPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
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

            modelBuilder.Entity("Contracts.Database.Post", b =>
                {
                    b.Navigation("ReadBy");
                });

            modelBuilder.Entity("Contracts.Database.User", b =>
                {
                    b.Navigation("ReadPosts");

                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
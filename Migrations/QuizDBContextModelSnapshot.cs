﻿// <auto-generated />
using System;
using AnotherQuizAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnotherQuizAPI.Migrations
{
    [DbContext(typeof(QuizDBContext))]
    partial class QuizDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AnotherQuizAPI.Model.QuizItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizListId");

                    b.ToTable("QuizItems");
                });

            modelBuilder.Entity("AnotherQuizAPI.Model.QuizList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuizName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuizLists");
                });

            modelBuilder.Entity("AnotherQuizAPI.Model.QuizListResult", b =>
                {
                    b.Property<int>("QuizListId")
                        .HasColumnType("int");

                    b.Property<int>("ResultId")
                        .HasColumnType("int");

                    b.HasKey("QuizListId", "ResultId");

                    b.HasIndex("ResultId");

                    b.ToTable("QuizListResult");
                });

            modelBuilder.Entity("AnotherQuizAPI.Model.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("AnotherQuizAPI.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AnotherQuizAPI.Model.QuizItem", b =>
                {
                    b.HasOne("AnotherQuizAPI.Model.QuizList", "QuizList")
                        .WithMany("QuizItems")
                        .HasForeignKey("QuizListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuizList");
                });

            modelBuilder.Entity("AnotherQuizAPI.Model.QuizListResult", b =>
                {
                    b.HasOne("AnotherQuizAPI.Model.QuizList", null)
                        .WithMany()
                        .HasForeignKey("QuizListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnotherQuizAPI.Model.Result", null)
                        .WithMany()
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnotherQuizAPI.Model.Result", b =>
                {
                    b.HasOne("AnotherQuizAPI.Model.User", "User")
                        .WithMany("Results")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AnotherQuizAPI.Model.QuizList", b =>
                {
                    b.Navigation("QuizItems");
                });

            modelBuilder.Entity("AnotherQuizAPI.Model.User", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
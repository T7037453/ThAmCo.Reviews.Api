﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThAmCo.Reviews.Api.Data;

#nullable disable

namespace ThAmCo.Reviews.Api.Migrations
{
    [DbContext(typeof(ReviewContext))]
    [Migration("20221227152427_InitalMigration")]
    partial class InitalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("ThAmCo.Reviews.Api.Data.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("anonymized")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("displayReview")
                        .HasColumnType("INTEGER");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("productId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("productReviewContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("productReviewRating")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
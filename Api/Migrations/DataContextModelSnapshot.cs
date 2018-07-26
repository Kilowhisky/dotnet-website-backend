﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Api.Entity;

namespace Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("Api.Models.Post", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("allowComments");

                    b.Property<string>("category");

                    b.Property<string>("content");

                    b.Property<DateTime>("createdAt");

                    b.Property<string>("title");

                    b.HasKey("id");

                    b.ToTable("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
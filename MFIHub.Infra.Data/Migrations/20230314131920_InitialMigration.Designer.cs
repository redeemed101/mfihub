﻿// <auto-generated />
using System;
using MFIHub.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MFIHub.Infra.Data.Migrations
{
    [DbContext(typeof(MFIHubContext))]
    [Migration("20230314131920_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MFIHub.Infra.Data.Entities.Topic", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RecordId");

                    b.ToTable("Topics");
                });
#pragma warning restore 612, 618
        }
    }
}
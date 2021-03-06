﻿// <auto-generated />
using System;
using EntityFrameworkCore.Sharp.Sample;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkCore.Sharp.Sample.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20181217152416_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("EntityFrameworkCore.Sharp.Sample.Models.Host", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Hosts");
                });
#pragma warning restore 612, 618
        }
    }
}

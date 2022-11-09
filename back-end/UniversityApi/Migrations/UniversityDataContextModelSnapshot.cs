﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UniversityApi.DbModels;

#nullable disable

namespace UniversityApi.Migrations
{
    [DbContext(typeof(UniversityDataContext))]
    partial class UniversityDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("UniversityApi.DbModels.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailablePlaces")
                        .HasColumnType("integer");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("FlagUrl")
                        .HasColumnType("text");

                    b.Property<bool>("IsObserved")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.Property<int>("SubjectAreaId")
                        .HasColumnType("integer");

                    b.Property<string>("SubjectAreaName")
                        .HasColumnType("text");

                    b.Property<string>("UniversityName")
                        .HasColumnType("text");

                    b.Property<string>("Website")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuotesApi2021.Data;

namespace QuotesApi2021.Migrations
{
    [DbContext(typeof(QuotesDbContext))]
    partial class QuotesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuotesApi2021.Models.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Text = "<p>Hloupost je největší zlo.</p>"
                        },
                        new
                        {
                            Id = 2,
                            Text = "<p>Kde blb, tam nebezpečno!</p>"
                        },
                        new
                        {
                            Id = 3,
                            Text = "<p>Jestliže se člověk hádá s blbcem víc, jak půl minuty, hádají se už dva blbci.</p>"
                        },
                        new
                        {
                            Id = 4,
                            Text = "<p>Největší životní lekcí je, že i blbci mají někdy pravdu.</p>"
                        },
                        new
                        {
                            Id = 5,
                            Text = "<p>If you’re going through hell, keep going.</p>"
                        });
                });

            modelBuilder.Entity("QuotesApi2021.Models.QuoteTag", b =>
                {
                    b.Property<int>("QuoteId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("QuoteId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("QuoteTag");

                    b.HasData(
                        new
                        {
                            QuoteId = 1,
                            TagId = 1
                        },
                        new
                        {
                            QuoteId = 1,
                            TagId = 2
                        },
                        new
                        {
                            QuoteId = 1,
                            TagId = 3
                        },
                        new
                        {
                            QuoteId = 2,
                            TagId = 1
                        },
                        new
                        {
                            QuoteId = 2,
                            TagId = 4
                        },
                        new
                        {
                            QuoteId = 2,
                            TagId = 3
                        },
                        new
                        {
                            QuoteId = 3,
                            TagId = 1
                        },
                        new
                        {
                            QuoteId = 3,
                            TagId = 4
                        },
                        new
                        {
                            QuoteId = 3,
                            TagId = 3
                        },
                        new
                        {
                            QuoteId = 4,
                            TagId = 5
                        },
                        new
                        {
                            QuoteId = 4,
                            TagId = 4
                        },
                        new
                        {
                            QuoteId = 4,
                            TagId = 3
                        },
                        new
                        {
                            QuoteId = 5,
                            TagId = 5
                        },
                        new
                        {
                            QuoteId = 5,
                            TagId = 6
                        },
                        new
                        {
                            QuoteId = 5,
                            TagId = 8
                        },
                        new
                        {
                            QuoteId = 5,
                            TagId = 7
                        });
                });

            modelBuilder.Entity("QuotesApi2021.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Text = "Werich, Jan",
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Text = "Hloupost",
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Text = "cs",
                            Type = 2
                        },
                        new
                        {
                            Id = 4,
                            Text = "Blbec",
                            Type = 0
                        },
                        new
                        {
                            Id = 5,
                            Text = "Churchill, Winston",
                            Type = 1
                        },
                        new
                        {
                            Id = 6,
                            Text = "Peklo",
                            Type = 0
                        },
                        new
                        {
                            Id = 7,
                            Text = "en",
                            Type = 2
                        },
                        new
                        {
                            Id = 8,
                            Text = "Těžkosti",
                            Type = 0
                        });
                });

            modelBuilder.Entity("QuotesApi2021.Models.QuoteTag", b =>
                {
                    b.HasOne("QuotesApi2021.Models.Quote", "Quote")
                        .WithMany()
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuotesApi2021.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quote");

                    b.Navigation("Tag");
                });
#pragma warning restore 612, 618
        }
    }
}
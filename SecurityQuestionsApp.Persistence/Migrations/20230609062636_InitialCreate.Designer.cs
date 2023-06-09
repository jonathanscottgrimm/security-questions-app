﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecurityQuestionsApp.Persistence;

#nullable disable

namespace SecurityQuestionsApp.Persistence.Migrations
{
    [DbContext(typeof(SecurityQuestionsAppContext))]
    [Migration("20230609062636_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SecurityQuestionsApp.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("SecurityQuestionsApp.Models.SecurityAnswer", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("SecurityQuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId", "SecurityQuestionId");

                    b.HasIndex("SecurityQuestionId");

                    b.ToTable("SecurityAnswers");
                });

            modelBuilder.Entity("SecurityQuestionsApp.Models.SecurityQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SecurityQuestions");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Question = "In what city were you born?"
                        },
                        new
                        {
                            Id = -2,
                            Question = "What is the name of your favorite pet?"
                        },
                        new
                        {
                            Id = -3,
                            Question = "What is your mother's maiden name?"
                        },
                        new
                        {
                            Id = -4,
                            Question = "What high school did you attend?"
                        },
                        new
                        {
                            Id = -5,
                            Question = "What was the mascot of your high school?"
                        },
                        new
                        {
                            Id = -6,
                            Question = "What was the make of your first car?"
                        },
                        new
                        {
                            Id = -7,
                            Question = "What was your favorite toy as a child?"
                        },
                        new
                        {
                            Id = -8,
                            Question = "Where did you meet your spouse?"
                        },
                        new
                        {
                            Id = -9,
                            Question = "What is your favorite meal?"
                        },
                        new
                        {
                            Id = -10,
                            Question = "Who is your favorite actor/actress?"
                        },
                        new
                        {
                            Id = -11,
                            Question = "What is your favorite album?"
                        });
                });

            modelBuilder.Entity("SecurityQuestionsApp.Models.SecurityAnswer", b =>
                {
                    b.HasOne("SecurityQuestionsApp.Models.Person", "Person")
                        .WithMany("SecurityAnswers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecurityQuestionsApp.Models.SecurityQuestion", "SecurityQuestion")
                        .WithMany("SecurityAnswers")
                        .HasForeignKey("SecurityQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("SecurityQuestion");
                });

            modelBuilder.Entity("SecurityQuestionsApp.Models.Person", b =>
                {
                    b.Navigation("SecurityAnswers");
                });

            modelBuilder.Entity("SecurityQuestionsApp.Models.SecurityQuestion", b =>
                {
                    b.Navigation("SecurityAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}

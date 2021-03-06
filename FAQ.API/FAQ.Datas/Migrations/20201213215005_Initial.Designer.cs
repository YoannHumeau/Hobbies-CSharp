﻿// <auto-generated />
using FAQ.Datas.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FAQ.Datas.Migrations
{
    [DbContext(typeof(FAQContext))]
    [Migration("20201213215005_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("FAQ.Datas.Models.AnswerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContentText")
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestionModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestionModelId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("FAQ.Datas.Models.QuestionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("FAQ.Datas.Models.QuestionTranslateModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestionModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionText")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("QuestionModelId");

                    b.HasIndex("Language", "QuestionModelId")
                        .IsUnique();

                    b.ToTable("QuestionsTranslates");
                });

            modelBuilder.Entity("FAQ.Datas.Models.AnswerModel", b =>
                {
                    b.HasOne("FAQ.Datas.Models.QuestionModel", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("FAQ.Datas.Models.QuestionTranslateModel", b =>
                {
                    b.HasOne("FAQ.Datas.Models.QuestionModel", null)
                        .WithMany("QuestionTranslates")
                        .HasForeignKey("QuestionModelId")
                        .HasConstraintName("ForeignKey_QuestionTranslateModel_QuestionModel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FAQ.Datas.Models.QuestionModel", b =>
                {
                    b.Navigation("QuestionTranslates");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Projects.Models;

namespace Projects.Migrations
{
    [DbContext(typeof(ProjectsDbContext))]
    [Migration("20180303220319_projectUpdate")]
    partial class projectUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projects.Models.Iteration", b =>
                {
                    b.Property<int>("IterationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedDate");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Name");

                    b.Property<int?>("ReleaseId");

                    b.Property<DateTime?>("StartDate");

                    b.HasKey("IterationId");

                    b.HasIndex("ReleaseId");

                    b.ToTable("Iteration");
                });

            modelBuilder.Entity("Projects.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Projects.Models.Release", b =>
                {
                    b.Property<int>("ReleaseId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("ActualReleaseDate");

                    b.Property<DateTime?>("ExpectedReleaseDate");

                    b.Property<string>("Name");

                    b.Property<int?>("ProjectId");

                    b.HasKey("ReleaseId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Release");
                });

            modelBuilder.Entity("Projects.Models.Story", b =>
                {
                    b.Property<int>("StoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("IterationId");

                    b.Property<int>("ProjectId");

                    b.Property<string>("Status");

                    b.HasKey("StoryId");

                    b.HasIndex("IterationId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("Projects.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.Property<int>("StoryId");

                    b.HasKey("TaskId");

                    b.HasIndex("StoryId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Projects.Models.Iteration", b =>
                {
                    b.HasOne("Project.Models.Release")
                        .WithMany("Iterations")
                        .HasForeignKey("ReleaseId");
                });

            modelBuilder.Entity("Projects.Models.Release", b =>
                {
                    b.HasOne("Projects.Models.Project")
                        .WithMany("Releases")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Projects.Models.Story", b =>
                {
                    b.HasOne("Projects.Models.Iteration")
                        .WithMany("Stories")
                        .HasForeignKey("IterationId");

                    b.HasOne("Projects.Models.Project")
                        .WithMany("Stories")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Projects.Models.Task", b =>
                {
                    b.HasOne("Project.Models.Story")
                        .WithMany("Tasks")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

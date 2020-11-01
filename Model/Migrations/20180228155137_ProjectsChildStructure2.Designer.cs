using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Projects.Models;

namespace Projects.Migrations
{
    [DbContext(typeof(ProjectsDbContext))]
    [Migration("20180228155137_ProjectsChildStructure2")]
    partial class ProjectsChildStructure2
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

            modelBuilder.Entity("Projects.Models.Iteration", b =>
                {
                    b.HasOne("Projects.Models.Release")
                        .WithMany("Iterations")
                        .HasForeignKey("ReleaseId");
                });

            modelBuilder.Entity("Projects.Models.Release", b =>
                {
                    b.HasOne("Projects.Models.Project")
                        .WithMany("Releases")
                        .HasForeignKey("ProjectId");
                });
        }
    }
}

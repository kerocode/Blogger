using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Blogger.Models;

namespace Blogger.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20170308024115_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blogger.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Blogger.Models.HeaderImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("ImageContent");

                    b.Property<string>("ImageName");

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.ToTable("HeaderImage");
                });

            modelBuilder.Entity("Blogger.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Body");

                    b.Property<int>("HeaderImageId");

                    b.Property<DateTime>("PublishedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 3, 7, 21, 41, 15, 271, DateTimeKind.Local));

                    b.Property<int>("PublisherId");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 3, 7, 21, 41, 15, 279, DateTimeKind.Local));

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Blogger.Models.PostTopic", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<int>("TopicId");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("PostId", "TopicId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("PostTopics");
                });

            modelBuilder.Entity("Blogger.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("Blogger.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("Blogger.Models.Post", b =>
                {
                    b.HasOne("Blogger.Models.Author", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Blogger.Models.HeaderImage", "HeaderImage")
                        .WithOne("Post")
                        .HasForeignKey("Blogger.Models.Post", "HeaderImageId");

                    b.HasOne("Blogger.Models.Publisher", "Publisher")
                        .WithMany("Posts")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Blogger.Models.PostTopic", b =>
                {
                    b.HasOne("Blogger.Models.Post", "Post")
                        .WithMany("PostTopics")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Blogger.Models.Topic", "Topic")
                        .WithMany("PostTopics")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

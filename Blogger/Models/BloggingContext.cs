using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Blogger.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
           : base(options)
        { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<PostTopic> PostTopics { get; set; }
        public DbSet<HeaderImage> HeaderImage { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<Topic>().ToTable("Topic");


            //modelBuilder.Entity<Topic>()
            //    .HasAlternateKey(c => c.Name)
            //    .HasName("AlternateKey_Name");
            modelBuilder.Entity<PostTopic>().HasKey(x => new { x.PostId, x.TopicId });

            modelBuilder.Entity<Post>()
                .Property(p => p.PublishedOn)
                .HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Post>().HasKey(p => p.Id);
            modelBuilder.Entity<Post>()
                .Property(p => p.UpdatedOn)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Post>()
                .HasOne(a => a.Author)
                .WithMany(c => c.Posts);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.HeaderImage)
                .WithOne(i => i.Post);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.PostTopics)
                .WithOne(a => a.Post);

            modelBuilder.Entity<Publisher>().HasKey(p => p.Id);
            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.Posts)
                .WithOne(a => a.Publisher);
            modelBuilder.Entity<Topic>().HasKey(p => p.Id);
            modelBuilder.Entity<Topic>()
                .HasMany(p => p.PostTopics)
                .WithOne(t => t.Topic);

            modelBuilder.Entity<Author>().HasKey(p => p.Id);
            modelBuilder.Entity<Author>()
                .HasMany(p => p.Posts)
                .WithOne(a => a.Author);
        }
    }
}

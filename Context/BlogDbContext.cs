using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Context;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options)
        : base(options) { }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=BlogEF6Api;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.ToTable("Blogs");

            entity.HasKey(e => e.BlogId);

            entity.Property(e => e.BlogId)
                .HasColumnName("BlogId")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .IsRequired();

            entity.Property(e => e.Url)
                .HasColumnName("Url")
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            entity.HasMany(e => e.Posts)
                .WithOne(p => p.Blog)
                .HasForeignKey(fr => fr.BlogId)
                .HasConstraintName("FK_POST_BLOG")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Posts");

            entity.HasKey(e => e.PostId);

            entity.Property(e => e.PostId)
                .HasColumnName("PostId")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .IsRequired();

            entity.Property(e => e.Title)
                .HasColumnName("Title")
                .HasColumnType("nvarchar(128)")
                .IsRequired();

            entity.Property(e => e.Content)
                .HasColumnName("Content")
                .HasColumnType("nvarchar(1024)")
                .IsRequired();

            entity.Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();
        });
    }
}

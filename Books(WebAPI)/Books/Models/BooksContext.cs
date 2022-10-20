using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Books.Models
{
    public partial class BooksContext : DbContext
    {
        public BooksContext()
        {
        }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BooksCategory> BooksCategory { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Queries> Queries { get; set; }
        public virtual DbSet<ReadingStatus> ReadingStatus { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-66SGHCF;Database=Books;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.AnswerId)
                    .HasName("PK__answers__33724318C8677FA2");

                entity.ToTable("answers");

                entity.Property(e => e.AnswerId).HasColumnName("answer_id");

                entity.Property(e => e.Answer)
                    .HasColumnName("answer")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QueryId).HasColumnName("query_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Query)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QueryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__answers__query_i__4222D4EF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__answers__user_id__5070F446");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__books__490D1AE1FD83316B");

                entity.ToTable("books");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.AuthorName)
                    .HasColumnName("author_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookImage)
                    .HasColumnName("book_image")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.BookName)
                    .HasColumnName("book_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasColumnType("decimal(4, 1)");
            });

            modelBuilder.Entity<BooksCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__books_ca__D54EE9B4EB0E96D2");

                entity.ToTable("books_category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("category_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__comments__E79576871D08207C");

                entity.ToTable("comments");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.AnswerId).HasColumnName("answer_id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__comments__answer__45F365D3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__comments__user_i__5165187F");
            });

            modelBuilder.Entity<Queries>(entity =>
            {
                entity.HasKey(e => e.QueryId)
                    .HasName("PK__queries__E793E3496C6F7BE2");

                entity.ToTable("queries");

                entity.Property(e => e.QueryId).HasColumnName("query_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImage)
                    .HasColumnName("profile_image")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Query)
                    .HasColumnName("query")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Queries)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__queries__user_id__4F7CD00D");
            });

            modelBuilder.Entity<ReadingStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__reading___3683B5315D509AFD");

                entity.ToTable("reading_status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Want To Read')");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.ReadingStatus)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__reading_s__book___33D4B598");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReadingStatus)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__reading_s__user___32E0915F");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__users__B9BE370FDFFEB02E");

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImage)
                    .HasColumnName("profile_image")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

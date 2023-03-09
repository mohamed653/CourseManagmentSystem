using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Models;

public partial class CoursesDbContext : DbContext
{
    public CoursesDbContext()
    {
    }

    public CoursesDbContext(DbContextOptions<CoursesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseLesson> CourseLessons { get; set; }

    public virtual DbSet<Trainee> Trainees { get; set; }

    public virtual DbSet<TraineeCourse> TraineeCourses { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=Courses_DB;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(200);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ParentId).HasColumnName("Parent_Id");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Category_Category");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.TrainerId).HasColumnName("Trainer_Id");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_Category");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK_Course_Trainee");

            entity.HasOne(d => d.TrainerNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK_Course_Trainer");
        });

        modelBuilder.Entity<CourseLesson>(entity =>
        {
            entity.ToTable("Course_Lessons");

            entity.Property(e => e.CourseId).HasColumnName("Course_Id");
            entity.Property(e => e.OrderNumber).HasColumnName("Order_Number");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Course).WithMany(p => p.CourseLessons)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_Lessons_Course");
        });

        modelBuilder.Entity<Trainee>(entity =>
        {
            entity.ToTable("Trainee");

            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Password).HasMaxLength(200);
        });

        modelBuilder.Entity<TraineeCourse>(entity =>
        {
            entity.HasKey(e => new { e.TraineeId, e.CourseId });

            entity.ToTable("Trainee_Courses");

            entity.Property(e => e.TraineeId).HasColumnName("Trainee_Id");
            entity.Property(e => e.CourseId).HasColumnName("Course_Id");
            entity.Property(e => e.RegisterationDate)
                .HasColumnType("datetime")
                .HasColumnName("Registeration_Date");

            entity.HasOne(d => d.Course).WithMany(p => p.TraineeCourses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trainee_Courses_Course");

            entity.HasOne(d => d.Trainee).WithMany(p => p.TraineeCourses)
                .HasForeignKey(d => d.TraineeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trainee_Courses_Trainee");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.ToTable("Trainer");

            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Website).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bai_thi.Entities;

public partial class ThiDotNetContext : DbContext
{
    public ThiDotNetContext()
    {
    }

    public ThiDotNetContext(DbContextOptions<ThiDotNetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddNewPage> AddNewPages { get; set; }

    public virtual DbSet<ClassRoom> ClassRooms { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS_THANH;Initial Catalog=thiDotNet;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddNewPage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__add_new___3213E83F2D7B47DB");

            entity.ToTable("add_new_pages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassRoomId).HasColumnName("class_room_id");
            entity.Property(e => e.ExamDate)
                .HasColumnType("datetime")
                .HasColumnName("exam_date");
            entity.Property(e => e.ExamDuration).HasColumnName("exam_duration");
            entity.Property(e => e.FacultiesId).HasColumnName("faculties_id");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.SubjectsId).HasColumnName("subjects_id");

            entity.HasOne(d => d.ClassRoom).WithMany(p => p.AddNewPages)
                .HasForeignKey(d => d.ClassRoomId)
                .HasConstraintName("FK__add_new_p__class__164452B1");

            entity.HasOne(d => d.Faculties).WithMany(p => p.AddNewPages)
                .HasForeignKey(d => d.FacultiesId)
                .HasConstraintName("FK__add_new_p__facul__182C9B23");

            entity.HasOne(d => d.Subjects).WithMany(p => p.AddNewPages)
                .HasForeignKey(d => d.SubjectsId)
                .HasConstraintName("FK__add_new_p__subje__173876EA");
        });

        modelBuilder.Entity<ClassRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__class_ro__3213E83F7D357286");

            entity.ToTable("class_rooms");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__facultie__3213E83F78D350FD");

            entity.ToTable("faculties");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__subjects__3213E83F75F15303");

            entity.ToTable("subjects");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

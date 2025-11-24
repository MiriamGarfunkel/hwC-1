using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lesson8;

public partial class CUsersMiriamDesktopהנדסאיםשנהבCLesson7MydbMdfContext : DbContext
{
    public CUsersMiriamDesktopהנדסאיםשנהבCLesson7MydbMdfContext()
    {
    }

    public CUsersMiriamDesktopהנדסאיםשנהבCLesson7MydbMdfContext(DbContextOptions<CUsersMiriamDesktopהנדסאיםשנהבCLesson7MydbMdfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Apartment> Apartments { get; set; }

    public virtual DbSet<Rent> Rents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Miriam\\Desktop\\הנדסאים שנה ב\\C#\\Lesson7\\myDb.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Apartmen__3214EC07A07281C4");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.Rooms).HasColumnName("rooms");
        });

        modelBuilder.Entity<Rent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rents__3214EC072D8D69BD");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ApartmentId).HasColumnName("apartmentId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Apartment).WithMany(p => p.Rents)
                .HasForeignKey(d => d.ApartmentId)
                .HasConstraintName("FK_Rents_ToTable_1");

            entity.HasOne(d => d.User).WithMany(p => p.Rents)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Rents_ToTable");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0798B28C9A");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.PhoneNunber)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("phoneNunber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

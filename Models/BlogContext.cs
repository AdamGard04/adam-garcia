using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prueba3_Adam_Garcia.Models;

public partial class BlogContext : DbContext
{
    public BlogContext()
    {
    }

    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Notificacion> Notificacions { get; set; }

    public virtual DbSet<Publicacion> Publicacions { get; set; }

    public virtual DbSet<Seguidor> Seguidors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comentar__C3B4DFCA237E3401");

            entity.ToTable("Comentario");

            entity.Property(e => e.DatePosted)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Text).HasMaxLength(1000);

            entity.HasOne(d => d.Post).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__PostI__2D27B809");

            entity.HasOne(d => d.User).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__UserI__2C3393D0");
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E124C3A092C");

            entity.ToTable("Notificacion");

            entity.Property(e => e.DateSent)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Text).HasMaxLength(255);

            entity.HasOne(d => d.RelatedComment).WithMany(p => p.Notificacions)
                .HasForeignKey(d => d.RelatedCommentId)
                .HasConstraintName("FK__Notificac__Relat__36B12243");

            entity.HasOne(d => d.RelatedPost).WithMany(p => p.Notificacions)
                .HasForeignKey(d => d.RelatedPostId)
                .HasConstraintName("FK__Notificac__Relat__35BCFE0A");

            entity.HasOne(d => d.User).WithMany(p => p.Notificacions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__UserI__34C8D9D1");
        });

        modelBuilder.Entity<Publicacion>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Publicac__AA126018E2AC01AF");

            entity.ToTable("Publicacion");

            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.DatePublished)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Publicacions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Publicaci__UserI__286302EC");
        });

        modelBuilder.Entity<Seguidor>(entity =>
        {
            entity.HasKey(e => e.FollowerId).HasName("PK__Seguidor__E859401938A48F53");

            entity.ToTable("Seguidor");

            entity.HasOne(d => d.FollowedUser).WithMany(p => p.SeguidorFollowedUsers)
                .HasForeignKey(d => d.FollowedUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Seguidor__Follow__30F848ED");

            entity.HasOne(d => d.User).WithMany(p => p.SeguidorUsers)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Seguidor__UserId__300424B4");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Usuario__1788CC4CF2FFC0ED");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534D5F1C185").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

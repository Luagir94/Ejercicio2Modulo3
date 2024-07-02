using EjercicioModulo3Clase2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EjercicioModulo3Clase2.Infrastructure.Repositories;

public partial class TaskRepository : DbContext
{
    public TaskRepository()
    {
    }

    public DbSet<Tarea> Tareas { get; set; }
    
    
    public TaskRepository(DbContextOptions<TaskRepository> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");

            entity.Property(e => e.DueDate)
                .HasColumnName("due_date");

            entity.Property(e => e.IsCompleted)
                .HasColumnName("is_completed");

            entity.Property(e => e.IsActive)
                .HasColumnName("is_active");
        });

        base.OnModelCreating(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
 
}
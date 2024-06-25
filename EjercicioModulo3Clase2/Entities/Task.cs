namespace EjercicioModulo3Clase2.Entities;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string DueDate { get; set; } 
    public bool IsCompleted { get; set; }
    public bool IsActive { get; set; }
}
using Microsoft.EntityFrameworkCore;
using Task = EjercicioModulo3Clase2.Entities.Task;

namespace Ejercicio4Modulo2;

public class DBContext : DbContext
{

    public DbSet<Task> Tasks { get; set; }
    
 
}
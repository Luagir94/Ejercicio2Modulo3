
using EjercicioModulo3Clase2.Domain.Entities;

namespace EjercicioModulo3Clase2.Domain.Contracts;

public interface ITaskService
{
    
    public List<Tarea> GetTasks();
    
    public Tarea? GetTaskById(int id);
    
    public Tarea? CreateTask(Tarea task);
    
    public Tarea? CompleteTask(int id);
    
    public Tarea? DisableTask(int id);
}
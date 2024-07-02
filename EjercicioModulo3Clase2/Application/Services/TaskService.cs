using EjercicioModulo3Clase2.Domain.Contracts;
using EjercicioModulo3Clase2.Domain.Entities;
using EjercicioModulo3Clase2.Infrastructure.Repositories;

namespace EjercicioModulo3Clase2.Application.Services;

public class TaskService : ITaskService
{
    
   private readonly TaskRepository _taskRepository;
    
    public TaskService(TaskRepository repository )
    {
        _taskRepository = repository;
    }
    
    public List<Tarea> GetTasks()
    {
       return  _taskRepository.Tareas.ToList();
    }

    public Tarea? GetTaskById(int id)
    {
        var task = _taskRepository.Tareas.FirstOrDefault(x => x.Id == id);

        return task;
    }

    public Tarea CreateTask(Tarea task)
    {
        _taskRepository.Tareas.Add(task);
        _taskRepository.SaveChanges();
        
        return task;
    }

    public Tarea? CompleteTask(int id)
    {
        var task = _taskRepository.Tareas.FirstOrDefault(x => x.Id == id);

        if (task == null)
        {
            return null;
        }
        
        task.IsCompleted = true;
        
        _taskRepository.SaveChanges();
        
        return task;
    }

    public Tarea? DisableTask(int id)
    {
        var task = _taskRepository.Tareas.FirstOrDefault(x => x.Id == id);
        
        if (task == null)
        {
            return null;
        }

        task.IsActive = false;

       
        _taskRepository.SaveChanges();
        
        return task;
    }
}
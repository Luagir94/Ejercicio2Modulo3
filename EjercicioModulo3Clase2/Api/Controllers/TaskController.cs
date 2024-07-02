using EjercicioModulo3Clase2.Domain.Contracts;
using EjercicioModulo3Clase2.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioModulo3Clase2.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        
        
        
        #region Pasos previos

        /*
         * 1 - Instalar EF Core y EF Core SQL Server
         * 2 - Crear contexto de base de datos y los modelos. Se puede usar Ingenieria Inversa de EF Core Power Tools
         * 3 - Configurar la inyección de dependencia del contexto tanto en Program.cs como en el controlador. No olvidar el string de conexión.
         * 4 - Las rutas de los endpoints queda a criterio de cada uno.
         * 5 - En este controlador, realizar los siguientes ejercicios:
         */


        private readonly ITaskService _taskService;

        public TaskController(
            ITaskService taskService)
        {
            _taskService = taskService;
        }

        #endregion


        #region Ejercicio 1

        // Crear un endpoint para obtener un listado de todas las tareas usando HTTP GET

        [Route("/")]
        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _taskService.GetTasks();
            return Ok(tasks);
        }

        #endregion

        #region Ejercicio 2

        // Crear un endpoint para obtener una tarea por ID usando HTTP GET

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetTask(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        #endregion

        #region Ejercicio 3

        // Crear un endpoint para crear una nueva tarea usando HTTP POST

        [Route("")]
        [HttpPost]
        public IActionResult CreateTask([FromBody] Tarea task)
        {

            _taskService.CreateTask(task);
            
            return NoContent();
        }

        #endregion

        #region Ejercicio 4

        // Crear un endpoint para marcar una tarea como completada usando HTTP PUT

        [Route("{id}/complete")]
        [HttpPut]
        public IActionResult CompleteTask(int id)
        {
            var task = _taskService.CompleteTask(id);
            if (task == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        #endregion

        #region Ejercicio 5

        // Crear un endpoint para dar de baja una tarea usando HTTP PUT (baja lógica)

        [Route("{id}/disable")]
        [HttpPut]
        public IActionResult DisableTask(int id)
        {
            var task = _taskService.DisableTask(id);
            if (task == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        #endregion
    }
}
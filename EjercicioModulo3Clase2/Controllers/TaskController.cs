using Ejercicio4Modulo2;
using Microsoft.AspNetCore.Mvc;
using Task = EjercicioModulo3Clase2.Entities.Task;

namespace EjercicioModulo3Clase2.Controllers
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


        private readonly DBContext _context;

        public TaskController(DBContext context)
        {
            _context = context;
        }

        #endregion


        #region Ejercicio 1

        // Crear un endpoint para obtener un listado de todas las tareas usando HTTP GET

        [Route("/")]
        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok(_context.Tasks.ToList());
        }

        #endregion

        #region Ejercicio 2

        // Crear un endpoint para obtener una tarea por ID usando HTTP GET

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(x => x.Id == id);
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
        public IActionResult CreateTask([FromBody] Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok(task);
        }

        #endregion

        #region Ejercicio 4

        // Crear un endpoint para marcar una tarea como completada usando HTTP PUT

        [Route("{id}")]
        [HttpPut]
        public IActionResult CompleteTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            task.IsCompleted = true;
            _context.SaveChanges();
            return Ok(task);
        }

        #endregion

        #region Ejercicio 5

        // Crear un endpoint para dar de baja una tarea usando HTTP PUT (baja lógica)

        [Route("{id}")]
        [HttpPut]
        public IActionResult DisableTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            task.IsActive = false;

            _context.SaveChanges();
            return Ok(task);
        }

        #endregion
    }
}
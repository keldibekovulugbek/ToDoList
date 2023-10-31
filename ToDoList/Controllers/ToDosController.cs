using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Entities;
using ToDoList.Service;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDosController(IToDoService toDoService) 
        {
            _toDoService = toDoService;
        }

        [HttpPost, Authorize()]
        public async ValueTask<IActionResult> CreateAsync(ToDo @toDo) 
        {
            await _toDoService.CreateAsync(toDo);

            return Ok(toDo);
        }
    }
}

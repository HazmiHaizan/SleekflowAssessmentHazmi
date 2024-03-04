using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using TodoAppHazmi2.Models;

namespace TodoAppHazmi2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly SieveProcessor _sieveProcessor;

        public TodoItemController(ApplicationDbContext context, SieveProcessor sieveProcessor)
        {
            _context = context;
            _sieveProcessor = sieveProcessor;
        }

        // GET: api/TodoItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemModel>>> GetTodoItems([FromQuery] SieveModel sieveModel)
        {
            var todoItemModel = _context.TodoItems.AsNoTracking();

            var res = _sieveProcessor.Apply(sieveModel, todoItemModel);

            return await res.ToListAsync();
        }

        //[HttpGet]
        //public JsonResult GetTodoItems(SieveModel sieveModel)
        //{
        //    var todoItemModel = _context.TodoItems.AsNoTracking();

        //    todoItemModel = _sieveProcessor.Apply(sieveModel, todoItemModel);

        //    return Json(todoItemModel.ToList()); ;
        //}


        // GET: api/TodoItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemModel>> GetTodoItemModel(int id)
        {
            var todoItemModel = await _context.TodoItems.FindAsync(id);

            if (todoItemModel == null)
            {
                return NotFound();
            }

            return todoItemModel;
        }

        // PUT: api/TodoItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItemModel(int id, TodoItemModel todoItemModel)
        {
            if (id != todoItemModel.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(todoItemModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItemModel>> PostTodoItemModel(TodoItemModel todoItemModel)
        {
            _context.TodoItems.Add(todoItemModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItemModel", new { id = todoItemModel.ItemId }, todoItemModel);
        }

        // DELETE: api/TodoItem/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItemModel(int id)
        {
            var todoItemModel = await _context.TodoItems.FindAsync(id);
            if (todoItemModel == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItemModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemModelExists(int id)
        {
            return _context.TodoItems.Any(e => e.ItemId == id);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Models;
using ToDoList.Api.Repositories;

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ToDoItemsController(ToDoItemRepository repository) : ControllerBase
    {
        private readonly ToDoItemRepository _repository = repository;

        [HttpGet("{id:int}", Name = "GetToDoItem")]
        public async Task<ActionResult<ToDoItem>> Get(int id)
        {
            try
            {
                var item = await _repository.GetByIdAsync(id);
                return item != null ?
                    Ok(new ToDoItem
                    {
                        Id = item.Id,
                        Description = item.Description,
                        IsCompleted = item.IsCompleted

                    }) :
                    NotFound($"NotFound: {id}.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet(Name = "GetToDoItems")]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> Get()
        {
            try
            {
                var items = await _repository.GetAllAsync();
                return items != null ? Ok(items) : NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "PutToDoItems")]
        public async Task<ActionResult> Put(ToDoItem model)
        {
            try
            {
                await _repository.UpdateAsync(model);
                return  Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(Name = "DeleteToDoItems")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "PostToDoItems")]
        public async Task<ActionResult> Post(string description, bool isCompleted = false)
        {
            try
            {
                var model = new ToDoItem { Description = description, IsCompleted = isCompleted };
                await _repository.AddAsync(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

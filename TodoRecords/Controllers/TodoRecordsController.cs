using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoRecords.Domain.DTOs;
using TodoRecords.Domain.Models;
using TodoRecords.IAppServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoRecords.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoRecordsController : ControllerBase
    {
        private readonly ITodoRecordAppService<TodoModel>  _todoRecordAppService;
        private readonly IMapper _mapper;

        public TodoRecordsController(ITodoRecordAppService<TodoModel> todoRecordAppService, IMapper mapper)
        {
            _todoRecordAppService = todoRecordAppService;
            _mapper = mapper;
        }


        // GET: api/<TodoRecordsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> Get()
        {
            return Ok(await _todoRecordAppService.GetAll());
        }

        // GET api/<TodoRecordsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoModel>> GetById(int id)
        {
            var entity = await _todoRecordAppService.GetById(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        // POST api/<TodoRecordsController>
        [HttpPost]
        public async Task<ActionResult<TodoModel>> Create(CrearTodoDTO entity)
        {
            TodoModel todoModel = _mapper.Map<TodoModel>(entity);
            var createdEntity = await _todoRecordAppService.Add(todoModel);
            return CreatedAtAction(nameof(GetById), new { id = createdEntity }, createdEntity);
        }

        // PUT api/<TodoRecordsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoModel>> Update(UpdateTodoDTO entity)
        {
            TodoModel todoModel = _mapper.Map<TodoModel>(entity);
            var updatedEntity = await _todoRecordAppService.Update(todoModel, todoModel.IdTodo);
            return Ok(updatedEntity);
        }

        // DELETE api/<TodoRecordsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _todoRecordAppService.DeleteById(id);
            if (!success) return NotFound();
            return Ok(success);
        }
    }
}

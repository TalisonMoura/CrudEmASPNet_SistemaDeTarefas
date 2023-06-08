using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> FindAllTasks()
        {
            List<TarefaModel> tasks = await _tarefaRepositorio.FindAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> FindById(int id)
        {
            TarefaModel tasks = await _tarefaRepositorio.FindById(id);
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Create([FromBody] TarefaModel taskModel)
        {
            TarefaModel tasks =  await _tarefaRepositorio.Create(taskModel);
            return Ok(tasks);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Update([FromBody] TarefaModel taskModel, int id)
        {
            taskModel.Id = id;
            TarefaModel tasks = await _tarefaRepositorio.Update(taskModel, id);
            return Ok(tasks);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Delete(int id)
        {
            bool deleted = await _tarefaRepositorio.Delete(id);
            return Ok(deleted);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> FindAllUsers()
        {
            List<UsuarioModel> users = await _usuarioRepositorio.FindAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> FindById(int id)
        {
            UsuarioModel users = await _usuarioRepositorio.FindById(id);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Create([FromBody] UsuarioModel userModel)
        {
            UsuarioModel user =  await _usuarioRepositorio.Create(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Update([FromBody] UsuarioModel userModel, int id)
        {
            userModel.Id = id;
            UsuarioModel user = await _usuarioRepositorio.Update(userModel, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Delete(int id)
        {
            bool deleted = await _usuarioRepositorio.Delete(id);
            return Ok(deleted);
        }
    }
}

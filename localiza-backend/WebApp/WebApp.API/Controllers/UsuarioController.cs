using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.API.DTOs;
using WebApp.API.Entities;
using WebApp.API.Repositories.Interfaces;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepos;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepos = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>>findAll()
        {
            List<Usuario> usuarios = await _usuarioRepos.findAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> findById(int id)
        {
            Usuario usuario = await _usuarioRepos.findById(id);
            return Ok(usuario);
        }
        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> findByEmailAndPawssword([FromBody]UsuarioDTO usuario)
        {
            Usuario foundUsuario = await _usuarioRepos.findByEmailAndPassword(usuario.email, usuario.senha);
            return Ok(foundUsuario);
        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> create([FromBody] Usuario usuario)
        {
            Usuario newUsuario =  await _usuarioRepos.create(usuario);
            return Ok(newUsuario);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> update([FromBody] Usuario usuario, int id)
        {
            Usuario newUsuario =  await _usuarioRepos.update(usuario, id);
            return Ok(newUsuario);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> delete(int id)
        {
            Boolean answer = await _usuarioRepos.delete(id);
            return Ok(answer);
        }


    }
}

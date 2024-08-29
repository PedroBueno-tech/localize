using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.API.Entities;
using WebApp.API.Repositories.Interfaces;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepos;

        public ClienteController(IClienteRepositorio clienteRepos)
        {
            _clienteRepos = clienteRepos;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> findAll()
        {
            List<Cliente> cliente = await _clienteRepos.findAll();
            return Ok(cliente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> findById(int id)
        {
            Cliente cliente = await _clienteRepos.findById(id);
            return Ok(cliente);
        }
        [HttpGet("getUser/{UsuarioId}")]
        public async Task<ActionResult<List<Cliente>>> findAllByUsuarioId(int UsuarioId)
        {
            List<Cliente> cliente = await _clienteRepos.findAllByUsuarioId(UsuarioId);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> create([FromBody] Cliente cliente)
        {
            Cliente newCliente = await _clienteRepos.create(cliente);
            return Ok(newCliente);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> update([FromBody] Cliente cliente, int id)
        {
            Cliente newCliente = await _clienteRepos.update(cliente, id);
            return Ok(newCliente);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> delete(int id)
        {
            Boolean answer = await _clienteRepos.delete(id);
            return Ok(answer);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.API.Entities;
using WebApp.API.Repositories.Interfaces;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CobrancaController : ControllerBase
    {

        private readonly ICobrancaRepositorio _cobrancaRepos;

        public CobrancaController(ICobrancaRepositorio cobrancaRepos)
        {
            _cobrancaRepos = cobrancaRepos;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cobranca>>> findAll()
        {
            List<Cobranca> cobranca = await _cobrancaRepos.findAll();
            return Ok(cobranca);
        }
        [HttpGet("getClient/{clienteId}")]
        public async Task<ActionResult<List<Cobranca>>> findAllByClientId(int clienteId)
        {
            List<Cobranca> cobranca = await _cobrancaRepos.findAllByClientId(clienteId);
            return Ok(cobranca);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Cobranca>> findById(int id)
        {
            Cobranca cobranca = await _cobrancaRepos.findById(id);
            return Ok(cobranca);
        }
        [HttpPost]
        public async Task<ActionResult<Cobranca>> create([FromBody] Cobranca cobranca)
        {
            Cobranca newCobranca = await _cobrancaRepos.create(cobranca);
            return Ok(newCobranca);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Cobranca>> update([FromBody] Cobranca cobranca, int id)
        {
            Cobranca newCobranca = await _cobrancaRepos.update(cobranca, id);
            return Ok(newCobranca);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> delete(int id)
        {
            Boolean answer = await _cobrancaRepos.delete(id);
            return Ok(answer);
        }
    }
}

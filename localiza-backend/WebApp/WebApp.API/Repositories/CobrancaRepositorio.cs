using Microsoft.EntityFrameworkCore;
using WebApp.API.Data;
using WebApp.API.Entities;
using WebApp.API.Repositories.Interfaces;

namespace WebApp.API.Repositories
{
    public class CobrancaRepositorio : ICobrancaRepositorio
    {
        private readonly LocalizeDBContext _dbContext;
        public CobrancaRepositorio(LocalizeDBContext localizeDBContext)
        {
            _dbContext = localizeDBContext;
        }
        public async Task<List<Cobranca>> findAll()
        {
            return await _dbContext.Cobrancas.ToListAsync();
        }
        public async Task<List<Cobranca>> findAllByClientId(int clientId)
        {
            return await _dbContext.Cobrancas.Where(x => x.clienteId == clientId).ToListAsync();
        }

        public async Task<Cobranca> findById(int id)
        {
            return await _dbContext.Cobrancas.FirstOrDefaultAsync(x => x.Id == id);
        }
        

        public async Task<Cobranca> create(Cobranca cobranca)
        {
            await _dbContext.Cobrancas.AddAsync(cobranca);
            await _dbContext.SaveChangesAsync();
            return cobranca;
        }
        public async Task<Cobranca> update(Cobranca cobranca, int id)
        {
            Cobranca cobrancaPorId = await findById(id);

            if (cobrancaPorId == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            cobrancaPorId.descricao = cobranca.descricao;
            cobrancaPorId.valor = cobranca.valor;
            cobrancaPorId.dataVencimento = cobranca.dataVencimento;
            cobrancaPorId.isPago = cobranca.isPago;
            cobrancaPorId.clienteId = cobranca.clienteId;


            _dbContext.Cobrancas.Update(cobrancaPorId);
            await _dbContext.SaveChangesAsync();
            return cobrancaPorId;


        }
        public async Task<bool> delete(int id)
        {
            Cobranca cobrancaPorId = await findById(id);

            if (cobrancaPorId == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            _dbContext.Cobrancas.Remove(cobrancaPorId);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}

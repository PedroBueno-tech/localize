using Microsoft.EntityFrameworkCore;
using WebApp.API.Data;
using WebApp.API.Entities;
using WebApp.API.Repositories.Interfaces;

namespace WebApp.API.Repositories
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly LocalizeDBContext _dbContext;
        public ClienteRepositorio(LocalizeDBContext localizeDBContext)
        {
            _dbContext = localizeDBContext;
        }
        public async Task<List<Cliente>> findAll()
        {
            return await _dbContext.Clientes.ToListAsync();
        }
        public async Task<List<Cliente>> findAllByUsuarioId(int UsuarioId)
        {
            return await _dbContext.Clientes.Where(x => x.usuarioId == UsuarioId).ToListAsync();
        }
        public async Task<Cliente> findById(int id)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Cliente> create(Cliente cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }
        public async Task<Cliente> update(Cliente cliente, int id)
        {
            Cliente clientePorId = await findById(id);

            if (clientePorId == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            clientePorId.nome = cliente.nome;
            clientePorId.documento = cliente.documento;
            clientePorId.telefone = cliente.telefone;
            clientePorId.endereco = cliente.endereco;
            clientePorId.usuarioId = cliente.usuarioId;

            _dbContext.Clientes.Update(clientePorId);
            await _dbContext.SaveChangesAsync();
            return clientePorId;

        }
        public async Task<bool> delete(int id)
        {
            Cliente clientePorId = await findById(id);

            if (clientePorId == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            _dbContext.Clientes.Remove(clientePorId);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}

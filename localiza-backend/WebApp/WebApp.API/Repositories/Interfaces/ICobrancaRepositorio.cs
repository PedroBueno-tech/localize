using WebApp.API.Entities;

namespace WebApp.API.Repositories.Interfaces
{
    public interface ICobrancaRepositorio
    {
        Task<List<Cobranca>> findAll();
        Task<Cobranca> findById(int id);
        Task<List<Cobranca>> findAllByClientId(int clientId);
        Task<Cobranca> create(Cobranca cobranca);
        Task<Cobranca> update(Cobranca cobranca, int id);
        Task<bool> delete(int id);
    }
}

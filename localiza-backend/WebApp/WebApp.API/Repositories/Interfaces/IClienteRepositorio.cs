using WebApp.API.Entities;

namespace WebApp.API.Repositories.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<List<Cliente>> findAll();
        Task<Cliente> findById(int id);
        Task<List<Cliente>> findAllByUsuarioId(int UsuarioId);
        Task<Cliente> create(Cliente cliente);
        Task<Cliente> update(Cliente cliente, int id);
        Task<bool> delete(int id);
    }
}

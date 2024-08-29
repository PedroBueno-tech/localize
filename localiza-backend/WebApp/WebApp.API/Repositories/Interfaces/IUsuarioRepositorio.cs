using WebApp.API.Entities;

namespace WebApp.API.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> findAll();
        Task<Usuario> findById(int id);
        Task<Usuario> findByEmail(String email);
        Task<Usuario> findByEmailAndPassword(string email, string senha);
        Task<Usuario> create(Usuario usuario);
        Task<Usuario> update(Usuario usuario, int id);
        Task<bool> delete(int id);
    }
}

using Microsoft.EntityFrameworkCore;
using WebApp.API.Data;
using WebApp.API.Entities;
using WebApp.API.Repositories.Interfaces;

namespace WebApp.API.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly LocalizeDBContext _dbContext;
        public UsuarioRepositorio(LocalizeDBContext localizeDBContext) 
        {
            _dbContext = localizeDBContext;
        }
        public async Task<List<Usuario>> findAll()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> findById(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario> findByEmail(String email)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.email == email);
        }

        public async Task<Usuario> findByEmailAndPassword(string email, string senha)
        {
           return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.email == email && x.senha == senha);
        }

        public async Task<Usuario> create(Usuario usuario)
        {
            Usuario verify = await findByEmail(usuario.email);
            if(verify != null)
            {
                throw new Exception("Email ja cadastrado");
            }
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }
        public async Task<Usuario> update(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await findById(id);

            if(usuarioPorId == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            usuarioPorId.nome = usuario.nome;
            usuarioPorId.email = usuario.email;
            usuarioPorId.senha = usuario.senha;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return usuarioPorId;


        }
        public async Task<bool> delete(int id)
        {
            Usuario usuarioPorId = await findById(id);

            if (usuarioPorId == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}

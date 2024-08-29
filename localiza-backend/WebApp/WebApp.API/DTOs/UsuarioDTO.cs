namespace WebApp.API.DTOs
{
    public class UsuarioDTO
    {
        public String email { get; set; }
        public String senha { get; set; }

        public UsuarioDTO(String email, String senha)
        {
            this.email = email;
            this.senha = senha;
        }
    }
}

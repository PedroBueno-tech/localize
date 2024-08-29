using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.API.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public String nome { get; set;}
        public String email { get; set;}
        public String senha { get; set;}

        public Usuario(String nome, String email, String senha)
        {
            this.nome = nome; 
            this.email = email;
            this.senha = senha;

        }
    }
}

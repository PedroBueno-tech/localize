using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.API.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public String nome { get; set;}
        public String documento { get; set;}
        public String telefone { get; set;}
        public String endereco { get; set;}
        public int usuarioId { get; set;}

        public Cliente(String nome, String documento, String telefone, String endereco, int usuarioId)
        {
            this.nome = nome;
            this.documento = documento;
            this.telefone = telefone;
            this.endereco = endereco;
            this.usuarioId = usuarioId;
        }
    }
}

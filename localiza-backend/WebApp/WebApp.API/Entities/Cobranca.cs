namespace WebApp.API.Entities
{
    public class Cobranca
    {
        public int Id { get; set; }
        public String descricao { get; set;}
        public Double valor { get; set;}
        public DateTime dataVencimento { get; set;}
        public Boolean isPago { get; set;}
        public int clienteId { get; set;}

        public Cobranca(String descricao, Double valor, DateTime dataVencimento, Boolean isPago, int clienteId)
        {
            this.descricao = descricao;
            this.valor = valor;
            this.dataVencimento = dataVencimento;
            this.isPago = isPago;
            this.clienteId = clienteId;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.API.Entities;

namespace WebApp.API.Data.Map
{
    public class CobrancaMap : IEntityTypeConfiguration<Cobranca>
    {
        public void Configure(EntityTypeBuilder<Cobranca> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.descricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.valor).IsRequired().HasMaxLength(255);
            builder.Property(x => x.dataVencimento).IsRequired();
            builder.Property(x => x.isPago).IsRequired();
            builder.Property(x => x.clienteId).IsRequired();
        }
    }
}

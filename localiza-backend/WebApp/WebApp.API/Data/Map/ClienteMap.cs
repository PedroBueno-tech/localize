using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.API.Entities;

namespace WebApp.API.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.documento).IsRequired();
            builder.Property(x => x.telefone).IsRequired();
            builder.Property(x => x.endereco).IsRequired();
            builder.Property(x => x.usuarioId).IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.API.Entities;

namespace WebApp.API.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.senha).IsRequired();
        }
    }
}

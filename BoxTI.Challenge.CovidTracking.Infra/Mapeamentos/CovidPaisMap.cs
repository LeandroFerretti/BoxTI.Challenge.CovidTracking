
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos
{
    public class CovidPaisMap : IEntityTypeConfiguration<CovidPais>
    {
        public void Configure(EntityTypeBuilder<CovidPais> builder)
        {
            builder.ToTable("Covid");
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey("Country_text");



        }
    }
}

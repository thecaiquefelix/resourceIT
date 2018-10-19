using ResourceIT.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceIT.Infra.Mappings
{
    public class DetalheMap : EntityTypeConfiguration<Detalhe>
    {
        public DetalheMap()
        {
            ToTable("Detalhe");
            HasKey(x => x.Id);
            Property(x => x.Telefone).HasMaxLength(15);
            Property(x => x.Endereco).HasMaxLength(150);
        }
    }
}

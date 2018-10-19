using ResourceIT.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceIT.Infra.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            HasKey(x => x.Id);
            Property(x => x.Nome).HasMaxLength(100).IsRequired();
            Property(x => x.Sobrenome).HasMaxLength(100);
            Property(x => x.Email).HasMaxLength(100);
            HasRequired(x => x.Detalhe);
        }
    }
}

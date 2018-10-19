using ResourceIT.Domain;
using ResourceIT.Infra.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceIT.Infra.DataContext
{
    public class ResourceITDataContext : DbContext
    {
        public ResourceITDataContext()
            :base("ResourceITConnectionString")
        {
            //Database.SetInitializer<ResourceITDataContext>(new ResourceITContextInitializer());
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new DetalheMap());
            base.OnModelCreating(modelBuilder);
        }


        //public class ResourceITContextInitializer : DropCreateDatabaseIfModelChanges<ResourceITDataContext>
        //{
        //    protected override void Seed(ResourceITDataContext context)
        //    {
        //        context.Detalhes.Add(new Detalhe { Id = 1, Telefone = "(11) 98903-0338", Endereco = "Rua Antonio Ribeiro Pina" });
        //        context.SaveChanges();

        //        context.Usuarios.Add(new Usuario { Id = 1, Nome = "Caique", Sobrenome = "Felix", Email = "caiquefgusmao@gmail.com", DetalheId = 1 });
        //        context.SaveChanges();
        //        base.Seed(context);
        //    }
        //}

        public System.Data.Entity.DbSet<ResourceIT.Domain.Detalhe> Detalhes { get; set; }

        public System.Data.Entity.DbSet<ResourceIT.Domain.Usuario> Usuarios { get; set; }
    }
}

namespace ResourceIT.Infra.Migrations
{
    using ResourceIT.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ResourceIT.Infra.DataContext.ResourceITDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ResourceIT.Infra.DataContext.ResourceITDataContext context)
        {
            context.Detalhes.Add(new Detalhe { Id = 1, Telefone = "(11) 98903-0338", Endereco = "Rua Antonio Ribeiro Pina" });
            context.SaveChanges();

            context.Usuarios.Add(new Usuario { Id = 1, Nome = "Caique", Sobrenome = "Felix", Email = "caiquefgusmao@gmail.com", DetalheId = 1 });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}

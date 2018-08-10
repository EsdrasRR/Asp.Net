using System.Data.Entity;

namespace EcommerceOsorioManha.Models
{
    public class Context : DbContext
    {
        //Mapear classes que vao virar tabela no banco
        public Context() : base("DbEcommerce")
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
    }
}
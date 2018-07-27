using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.Models
{
    public class Context : DbContext
    {
        //Mapear classes que vao virar tabela no banco

        public int DbSet<Produto> Produtos { Get; Set; }
    }
}
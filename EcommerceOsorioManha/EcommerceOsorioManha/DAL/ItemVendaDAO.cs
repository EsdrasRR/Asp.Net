using EcommerceOsorioManha.Models;
using EcommerceOsorioManha.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAL
{
    public class ItemVendaDAO
    {
        public static Context ctx = SingletonContext.GetInstance();

        public static List<ItemVenda> BuscarItensVendaPorCarrinhoId()
        {
            string carrinhoId = Sessao.RetornarCarrinhoId();
            return ctx.ItensVenda.Include("ProdutoVenda").Where( x=> x.CarrinhoId.Equals(carrinhoId)).ToList();
        }
        public static void CadastrarVenda(ItemVenda venda)
        {
            ctx.ItensVenda.Add(venda);
            ctx.SaveChanges();
        }
    }
}
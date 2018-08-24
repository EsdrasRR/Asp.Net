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
            string carrinhoId = Sessao.RetornarCarrinhoId();

            ItemVenda item = ctx.ItensVenda.
                Include("ProdutoVenda").FirstOrDefault(
                x => x.ProdutoVenda.ProdutoId == venda.ProdutoVenda.ProdutoId &&
                x.CarrinhoId.Equals(carrinhoId));

            if (item == null)
            {
                ctx.ItensVenda.Add(venda);
            }
            else
            {
                item.QtdVenda++;
            }
            ctx.SaveChanges();
        }
        public static void RemoverItem(int id)
        {
            ctx.ItensVenda.Remove(BuscaItemPorId(id));
            ctx.SaveChanges();
        }

        private static ItemVenda BuscaItemPorId(int id)
        {
            return ctx.ItensVenda.Find(id);
        }

        public static double RetornarTotalCarrinho()
        {
            return BuscarItensVendaPorCarrinhoId().Sum(x => x.QtdVenda * x.PrecoVenda);
        }
        public static double RetornarQuantidadeItensCarrinho()
        {
            return BuscarItensVendaPorCarrinhoId().Sum(x => x.QtdVenda);
        }
        public static void AdicionarItem(int id)
        {
            ItemVenda item = ctx.ItensVenda.Find(id);
            item.QtdVenda++;
            ctx.SaveChanges();
        }
        public static void DiminuirItem(int id)
        {
            ItemVenda item = ctx.ItensVenda.Find(id);
            if (item.QtdVenda > 1)
            {
                item.QtdVenda--;
                ctx.SaveChanges();
            }
        }
    }
}
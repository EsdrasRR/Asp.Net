using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EcommerceOsorioManha.DAL
{
    public class ProdutoDAO
    {

        private static Context ctx = new Context();

        public static List<Produto> RetornarProdutos()
        {
            return ctx.Produtos.ToList();
        }

        public static void CadastrarProduto(Produto produto)
        {
            ctx.Produtos.Add(produto);
            ctx.SaveChanges();
        }

        public static void RemoverProduto(int id)
        {
            ctx.Produtos.Remove(BuscarProdutoPorId(id));
            ctx.SaveChanges();
        }

        public static void AlterarProduto(int id)
        {
           ctx.Produtos.Find(id);
        }

        public static void AlterarProduto(Produto produtoAlterado)
        {
            Produto produtoOriginal = ProdutoDAO.BuscarProdutoPorId(produtoAlterado.ProdutoId);

            produtoOriginal.Nome = produtoAlterado.Nome;
            produtoOriginal.Descricao = produtoAlterado.Descricao;
            produtoOriginal.Preco = produtoAlterado.Preco;
            produtoOriginal.Categoria = produtoAlterado.Categoria;

            ctx.Entry(produtoAlterado).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static Produto BuscarProdutoPorId(int id)
        {
                  return ctx.Produtos.Find(id);
        }
    }
}
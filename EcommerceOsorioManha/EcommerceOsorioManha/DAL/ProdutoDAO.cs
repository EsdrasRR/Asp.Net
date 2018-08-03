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

        public static void CadastrarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {

            Produto produto = new Produto
            {
                Nome = txtNome,
                Descricao = txtDescricao,
                Preco = Convert.ToDouble(txtPreco),
                Categoria = txtCategoria,
            };

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

        public static void AlterarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria, int txtId)
        {
            Produto produto = BuscarProdutoPorId(txtId);
            produto.Nome = txtNome;
            produto.Descricao = txtDescricao;
            produto.Preco = Convert.ToDouble(txtPreco);
            produto.Categoria = txtCategoria;

            ctx.Entry(produto).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static Produto BuscarProdutoPorId(int id)
        {
                  return ctx.Produtos.Find(id);
        }
    }
}
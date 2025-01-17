﻿using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EcommerceOsorioManha.DAL
{
    public class ProdutoDAO
    {

        private static Context ctx = SingletonContext.GetInstance();
        public static List<Produto> RetornarProdutos()
        {
            return ctx.Produtos.Include("Categoria").ToList();
        }

        public static bool CadastrarProduto(Produto produto)
        {
            if (BuscarProdutoPorNome(produto) == null)
            {
                ctx.Produtos.Add(produto);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        public static List<Produto> BuscarProdutosPorCategoria(int? id)
        {
            return ctx.Produtos.
                Include("Categoria").Where(x => x.Categoria.CategoriaID == id).
                ToList();
        }

        public static Produto BuscarProdutoPorNome(Produto produto)
        {
            return ctx.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome));
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

        public static bool AlterarProduto(Produto produto)
        {
            if (ctx.Produtos.FirstOrDefault
                (x => x.Nome.Equals(produto.Nome) &&
                x.ProdutoId != produto.ProdutoId) == null)
            {
                ctx.Entry(produto).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Produto BuscarProdutoPorId(int id)
        {
                  return ctx.Produtos.Find(id);
        }
    }
}
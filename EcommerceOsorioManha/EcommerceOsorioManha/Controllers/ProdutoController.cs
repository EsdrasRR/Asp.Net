using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class ProdutoController : Controller
    {
        Models.Context ctx = new Models.Context();

        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Produtos = ctx.Produtos.ToList();
            List<EcommerceOsorioManha.Models.Produto> produtos = ViewBag.Produtos;
            return View();
        }
        public ActionResult CadastrarProduto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {
            Models.Produto produto = new Models.Produto
            {
                Nome = txtNome,
                Descricao = txtDescricao,
                Preco = Convert.ToDouble(txtPreco),
                Categoria = txtCategoria,
            };

            ctx.Produtos.Add(produto);
            ctx.SaveChanges();

            return RedirectToAction("Index", "Produto");
        }
        public ActionResult RemoverProduto( int id)
        {
            ctx.Produtos.Remove(ctx.Produtos.Find(id));
            ctx.SaveChanges();
            return RedirectToAction("Index", "Produto"); 
        }
        public ActionResult AlterarProduto ( int id)
        {
            ViewBag.Produto = ctx.Produtos.Find(id);

            return View();
        }
        [HttpPost]
        public ActionResult AlterarProduto (string txtNome, string txtDescricao, string txtPreco, string txtCategoria, int txtId)
        {
            Models.Produto produto = ctx.Produtos.Find(txtId);
            produto.Nome = txtNome;
            produto.Descricao = txtDescricao;
            produto.Preco = Convert.ToDouble(txtPreco);
            produto.Categoria = txtCategoria;

            ctx.Entry(produto).State = EntityState.Modified;
            ctx.SaveChanges();
            return RedirectToAction("Index", "Produto");
        }
    }
}
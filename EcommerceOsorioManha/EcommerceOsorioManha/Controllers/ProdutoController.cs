using EcommerceOsorioManha.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class ProdutoController : Controller
    {
        Context ctx = new Context();

        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Produtos = ctx.Produtos.ToList();
            return View();
        }
        public ActionResult CadastrarProduto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {
            Produto produto = new Produto
            {
                Nome = txtNome,
                Descricao = txtPreco,
                Preco = Convert.ToDouble(txtPreco),
                Categoria = txtCategoria
            };

            ctx.Produtos.Add(produto);
            ctx.SaveChanges();

            return RedirectToAction("Index", "Produto");
        }
    }
}
using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;
using System;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class ProdutoController : Controller
    {

        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(ProdutoDAO.RetornarProdutos());
        }
        public ActionResult CadastrarProduto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {

            ProdutoDAO.CadastrarProduto(produto);

            return RedirectToAction("Index", "Produto");
        }
        public ActionResult RemoverProduto(int id)
        {
            ProdutoDAO.RemoverProduto(id);
            return RedirectToAction("Index", "Produto");
        }
        public ActionResult AlterarProduto(int id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }
        [HttpPost]
        public ActionResult AlterarProduto(Produto produtoAlterado)
        {

            ProdutoDAO.AlterarProduto(produtoAlterado);

            return RedirectToAction("Index", "Produto");
        }
    }
}
using EcommerceOsorioManha.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class ProdutoController : Controller
    {

        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Produtos = ProdutoDAO.RetornarProdutos();
            return View();
        }
        public ActionResult CadastrarProduto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {

            ProdutoDAO.CadastrarProduto(txtNome, txtDescricao, txtPreco, txtCategoria);

            return RedirectToAction("Index", "Produto");
        }
        public ActionResult RemoverProduto(int id)
        {
            ProdutoDAO.RemoverProduto(id);
            return RedirectToAction("Index", "Produto");
        }
        public ActionResult AlterarProduto(int id)
        {
            ViewBag.Produto = ProdutoDAO.BuscarProdutoPorId(id);
            return View();
        }
        [HttpPost]
        public ActionResult AlterarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria, int txtId)
        {

            ProdutoDAO.AlterarProduto(txtNome, txtDescricao, txtPreco, txtCategoria, txtId);

            return RedirectToAction("Index", "Produto");
        }
    }
}
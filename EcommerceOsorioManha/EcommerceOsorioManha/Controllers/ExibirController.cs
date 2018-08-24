using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;
using EcommerceOsorioManha.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class ExibirController : Controller
    {

        // GET: Home
        public ActionResult Home(int? id)
        {
            ViewBag.Categorias = CategoriaDAO.RetornarCategorias();
            if (id == null)
            {
                return View(ProdutoDAO.RetornarProdutos());
            }

            return View(ProdutoDAO.BuscarProdutosPorCategoria(id));
        }

        public ActionResult Detalhes(int id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }

        public ActionResult AdicionarAoCarrinho(int id)
        {

            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);

            ItemVenda itemVenda = new ItemVenda
            {
                ProdutoVenda = produto,
                QtdVenda = 1,
                PrecoVenda = produto.Preco,
                Data = DateTime.Now,
                CarrinhoId = Sessao.RetornarCarrinhoId()
            };

            ItemVendaDAO.CadastrarVenda(itemVenda);
            return RedirectToAction("CarrinhoCompras");

        }

        public ActionResult CarrinhoCompras()
        {
            return View(ItemVendaDAO.BuscarItensVendaPorCarrinhoId());
        }
        public ActionResult RemoverItem(int id)
        {
            ItemVendaDAO.RemoverItem(id);
            return RedirectToAction("Home", "Usuario");
        }
        public ActionResult AdicionarItem(int id)
        {
            ItemVendaDAO.AdicionarItem(id);
            return RedirectToAction("CarrinhoCompras", "Exibir");
        }

        public ActionResult DiminuirItem(int id)
        {
            ItemVendaDAO.DiminuirItem(id);
            return RedirectToAction("CarrinhoCompras", "Exibir");
        }
    }
}